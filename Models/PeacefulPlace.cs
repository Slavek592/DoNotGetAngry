using System;
using System.Collections.Generic;

namespace SP220922.Models
{
    public class PeacefulPlace : Place
    {
        private List<Figure> _figures;

        public PeacefulPlace(int number)
        {
            _figures = new List<Figure>();
            Number = number;
        }
        public override void GoHere(Figure figure)
        {
            _figures.Add(figure);
        }

        public override void GoOut(Figure figure)
        {
            _figures.Remove(figure);
        }

        public override void Draw()
        {
            Console.Write(Number.ToString() + ": ");
            foreach (Figure figure in _figures)
            {
                Console.Write(figure.GetColor() + " ");
            }
            if (Number % 10 == 0)
                Console.WriteLine("");
        }
    }
}