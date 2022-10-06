using System.Globalization;

namespace SP220922.Models
{
    public class Map
    {
        public Place[] Places;
        public int Length;

        /*public Map(int length)
        {
            Length = length;
            Places = new Place[length + 1];
            Places[0] = new PeacefulPlace(0);
            for (int i = 1; i < length; i++)
            {
                Places[i] = new AggressivePlace(i);
            }
            Places[length] = new PeacefulPlace(length);
        }*/

        public void Draw()
        {
            foreach (Place place in Places)
            {
                place.Draw();
            }
        }
    }
}