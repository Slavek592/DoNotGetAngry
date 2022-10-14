namespace SP220922.Models
{
    public abstract class Place
    {
        protected int Number;
        public abstract void GoHere(Figure figure);
        public abstract void GoOut(Figure figure);
        public abstract void Draw();
    }
}