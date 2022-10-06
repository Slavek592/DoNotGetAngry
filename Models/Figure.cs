using System;

namespace SP220922.Models
{
    public class Figure
    {
        public bool Started;
        public int Place;
        public bool Ended;
        private int _lengthOfGame;

        public Figure(int lengthOfGame)
        {
            _lengthOfGame = lengthOfGame;
            Started = false;
            Place = 0;
            Ended = false;
        }

        public void Begin()
        {
            Started = true;
            Console.WriteLine("The figure is starting.");
        }

        public void Go(int length)
        {
            Place += length;
            if (Place >= _lengthOfGame)
                Ended = true;
        }
    }
}