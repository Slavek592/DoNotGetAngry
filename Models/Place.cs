namespace SP220922.Models
{
    public abstract class Place
    {
        public int Number;

        /*protected Place(int number)
        {
            Number = number;
        }*/
        public abstract void GoHere(Figure figure);
        public abstract void GoOut(Figure figure);
        public abstract void Draw();
    }
}