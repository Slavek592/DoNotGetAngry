using System;

namespace SP220922.Models
{
    public class Player
    {
        private String _color;
        public Figure[] Figures;
        //private Player[] _friends;
        private Map _map;

        public Player(String color, int numberOfFigures, int lengthOfGame, Map map)
        {
            Figures = new Figure[numberOfFigures];
            for (int i = 0; i < numberOfFigures; i++)
            {
                Figures[i] = new Figure(lengthOfGame, color);
                Figures[i].Started = false;
            }
            _color = color;
            _map = map;
            Console.WriteLine("Player " + _color + " is ready.");
            Figures[0].Begin();
            _map.Places[0].GoHere(Figures[0]);
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
                        _map.Places[0].GoHere(Figures[i]);
                        break;
                    }
                }
            }
            _map.Draw();
            State();
            Console.WriteLine("Which figure?");
            int chosenFigure;
            bool correctInt = Int32.TryParse(Console.ReadLine(), out chosenFigure);
            if (correctInt)
            {
                if (chosenFigure < 0 || chosenFigure >= Figures.Length)
                    Console.WriteLine("No figure moved.");
                else
                {
                    if (!Figures[chosenFigure].Ended && Figures[chosenFigure].Started)
                    {
                        _map.Places[Figures[chosenFigure].Place].GoOut(Figures[chosenFigure]);
                        Figures[chosenFigure].Go(number);
                        if (Figures[chosenFigure].Place >= _map.Length)
                        {
                            _map.Places[_map.Length].GoHere(Figures[chosenFigure]);
                        }
                        else
                        {
                            _map.Places[Figures[chosenFigure].Place].GoHere(Figures[chosenFigure]);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("The figure was chosen automatically.");
                for (int i = 0; i < Figures.Length; i++)
                {
                    if (!Figures[i].Ended && Figures[i].Started)
                    {
                        _map.Places[Figures[i].Place].GoOut(Figures[i]);
                        Figures[i].Go(number);
                        if (Figures[i].Place >= _map.Length)
                        {
                            _map.Places[_map.Length].GoHere(Figures[i]);
                        }
                        else
                        {
                            _map.Places[Figures[i].Place].GoHere(Figures[i]);
                        }
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