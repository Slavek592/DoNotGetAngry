namespace SP220922.Models
{
    public class PeacefulLinearMap : Map
    {
        public PeacefulLinearMap(int length)
        {
            Length = length;
            Places = new Place[length + 1];
            for (int i = 0; i < length + 1; i++)
            {
                Places[i] = new PeacefulPlace(i);
            }
        }
    }
}