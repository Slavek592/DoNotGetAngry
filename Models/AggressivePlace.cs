using System;
namespace SP220922.Models
{
    public class AggressivePlace : Place
    {
        private Figure _figure;

        public AggressivePlace(int number)
        {
            Number = number;
        }

        public override void GoHere(Figure figure)
        {
            if (_figure != null)
            {
                _figure.GoBack();
            }
            _figure = figure;
        }

        public override void GoOut(Figure figure)
        {
            _figure = null;
        }

        public override void Draw()
        {
            Console.Write(Number.ToString() + ": ");
            if (_figure != null)
            {
                Console.Write(_figure.GetColor() + " ");
            }
            if (Number % 10 == 0)
                Console.WriteLine("");
        }
    }
}