namespace SP220922.Models
{
    public class AggressiveLinearMap : Map
    {
        public AggressiveLinearMap(int length)
        {
            Length = length;
            Places = new Place[length + 1];
            Places[0] = new PeacefulPlace(0);
            for (int i = 1; i < length; i++)
            {
                Places[i] = new AggressivePlace(i);
            }
            Places[length] = new Home(length);
        }
    }
}