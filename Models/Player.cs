using System;

namespace SP220922.Models
{
    public class Player
    {
        private String _color;
        public Figure[] Figures;
        //private Player[] _friends;

        public Player(String color, int numberOfFigures, int lengthOfGame)
        {
            Figures = new Figure[numberOfFigures];
            for (int i = 0; i < numberOfFigures; i++)
            {
                Figures[i] = new Figure(lengthOfGame);
                Figures[i].Started = false;
            }
            _color = color;
            Console.WriteLine("Player " + _color + " is ready.");
            Figures[0].Begin();
        }

        public void State()
        {
            Console.WriteLine("Player: " + _color);
            for (int i = 0; i < Figures.Length; i++)
            {
                Console.Write("Figure " + i.ToString() + " is at the place " + Figures[i].Place.ToString() + ", ");
                if (Figures[i].Ended)
                    Console.WriteLine("it already ended.");
                else if (Figures[i].Started)
                    Console.WriteLine("it already started.");
                else
                    Console.WriteLine("it has not started.");
            }
        }

        public void Play()
        {
            Random random = new Random();
            int number = random.Next(1, 7);
            Console.WriteLine("You threw " + number.ToString());
            if (number == 6)
            {
                for (int i = 0; i < Figures.Length; i++)
                {
                    if (!Figures[i].Started)
                    {
                        Figures[i].Begin();
                        break;
                    }
                }
            }
            State();
            Console.WriteLine("Which figure?");
            int chosenFigure;
            bool correctInt = Int32.TryParse(Console.ReadLine(), out chosenFigure);
            if (correctInt)
            {
                if (chosenFigure < 0 || chosenFigure >= Figures.Length)
                    Console.WriteLine("No figure moved.");
                else
                    Figures[chosenFigure].Go(number);
            }
            else
            {
                Console.WriteLine("The figure was chosen automatically.");
                for (int i = 0; i < Figures.Length; i++)
                {
                    if (!Figures[i].Ended && Figures[i].Started)
                    {
                        Figures[i].Go(number);
                        break;
                    }
                }
            }
        }

        public bool CheckWin()
        {
            bool end = true;
            for (int i = 0; i < Figures.Length; i++)
            {
                if (!Figures[i].Ended)
                    end = false;
            }

            if (end)
                Console.WriteLine("Player " + _color + " has won!");
            return end;
        }
    }
}