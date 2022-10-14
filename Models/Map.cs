using System;

namespace SP220922.Models
{
    public abstract class Map
    {
        protected Place[] Places;
        protected int Length;

        public void Draw()
        {
            foreach (Place place in Places)
            {
                place.Draw();
            }
            Console.WriteLine("");
        }

        public int GetLength()
        {
            return Length;
        }

        public void GoHere(int number, Figure figure)
        {
            Places[number].GoHere(figure);
        }

        public void GoOut(int number, Figure figure)
        {
            Places[number].GoOut(figure);
        }
    }
}