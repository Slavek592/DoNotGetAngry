using System;
using System.Linq;

namespace SP220922.Models
{
    public class Player
    {
        private readonly String _color;
        private Figure[] _figures;
        private Map _map;

        public Player(String color, int numberOfFigures, int lengthOfGame, Map map)
        {
            _figures = new Figure[numberOfFigures];
            for (int i = 0; i < numberOfFigures; i++)
            {
                _figures[i] = new Figure(lengthOfGame, color);
            }
            _color = color;
            _map = map;
            Console.WriteLine("Player " + _color + " is ready.");
            _figures[0].Begin();
            _map.GoHere(0, _figures[0]);
        }

        public void State()
        {
            Console.WriteLine("Player: " + _color);
            for (int i = 0; i < _figures.Length; i++)
            {
                Console.Write("Figure " + i.ToString() + " is at the place "
                              + _figures[i].GetPlace().ToString() + ", ");
                if (_figures[i].GetEnded())
                    Console.WriteLine("it already ended.");
                else if (_figures[i].GetStarted())
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
                for (int i = 0; i < _figures.Length; i++)
                {
                    if (!_figures[i].GetStarted())
                    {
                        _figures[i].Begin();
                        _map.GoHere(0, _figures[i]);
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
                if (chosenFigure < 0 || chosenFigure >= _figures.Length)
                    Console.WriteLine("No figure moved.");
                else
                {
                    if (!_figures[chosenFigure].GetEnded() && _figures[chosenFigure].GetStarted())
                    {
                        _map.GoOut(_figures[chosenFigure].GetPlace(), _figures[chosenFigure]);
                        _figures[chosenFigure].Go(number);
                        if (_figures[chosenFigure].GetPlace() >= _map.GetLength())
                        {
                            _map.GoHere(_map.GetLength(), _figures[chosenFigure]);
                        }
                        else
                        {
                            _map.GoHere(_figures[chosenFigure].GetPlace(), _figures[chosenFigure]);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("The figure was chosen automatically.");
                for (int i = 0; i < _figures.Length; i++)
                {
                    if (!_figures[i].GetEnded() && _figures[i].GetStarted())
                    {
                        _map.GoOut(_figures[i].GetPlace(), _figures[i]);
                        _figures[i].Go(number);
                        if (_figures[i].GetPlace() >= _map.GetLength())
                        {
                            _map.GoHere(_map.GetLength(), _figures[i]);
                        }
                        else
                        {
                            _map.GoHere(_figures[i].GetPlace(), _figures[i]);
                        }
                        break;
                    }
                }
            }
        }

        public bool CheckWin()
        {
            if (_figures.All(f => f.GetEnded()))
            {
                Console.WriteLine("Player " + _color + " has won!");
                return true;
            }
            else
                return false;
        }
    }
}