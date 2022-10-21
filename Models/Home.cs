using System.Collections.Generic;

namespace SP220922.Models
{
    public class Home : PeacefulPlace
    {
        public Home(int number)
        {
            Number = number;
        }

        public override void GoHere(Figure figure)
        {
            base.GoHere(figure);
            figure.YouEnded();
        }
    }
}