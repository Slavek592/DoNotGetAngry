using System;

namespace SP220922.Models
{
    public class Figure
    {
        private bool _started;
        private int _place;
        private bool _ended;
        private readonly string _color;

        public Figure(string color)
        {
            _started = false;
            _place = 0;
            _ended = false;
            _color = color;
        }

        public void Begin()
        {
            _started = true;
            Console.WriteLine("The figure is starting.");
        }

        public void Go(int length)
        {
            _place += length;
        }

        public void YouEnded()
        {
            _ended = true;
        }

        public int GetPlace()
        { return _place; }
        
        public bool GetStarted()
        { return _started; }
        
        public bool GetEnded()
        { return _ended; }

        public string GetColor()
        { return _color; }

        public void GoBack()
        {
            _place = 0;
            _started = false;
        }
    }
}