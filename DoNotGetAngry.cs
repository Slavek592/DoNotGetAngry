using System;
using SP220922.Models;

namespace SP220922
{
    public class DoNotGetAngry
    {
        public static void Main()
        {
            bool firstGame = true;
            int numberOfFigures = 1;
            int numberOfPlayers = 1;
            int lengthOfGame = 1;
            String[] chosenColors = new string[numberOfPlayers];
            
            while (true)
            {
                bool newSettings;
                if (firstGame)
                {
                    newSettings = true;
                }
                else
                {
                    Console.WriteLine("Do You want to change settings?");
                    String answer = Console.ReadLine().ToLower();
                    if (answer.Contains("no"))
                        newSettings = false;
                    else
                        newSettings = true;
                }

                if (newSettings)
                {
                    while (true)
                    {
                        Console.WriteLine("Choose the number of figures of every player.");
                        bool correctInt = Int32.TryParse(Console.ReadLine(), out numberOfFigures);
                        if (correctInt && numberOfFigures > 0)
                            break;
                        else
                        {
                            Console.WriteLine("It was not a correct int.");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Choose the number of players.");
                        bool correctInt = Int32.TryParse(Console.ReadLine(), out numberOfPlayers);
                        if (correctInt && numberOfPlayers > 0)
                            break;
                        else
                        {
                            Console.WriteLine("It was not a correct int.");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Choose the lenght of the game.");
                        bool correctInt = Int32.TryParse(Console.ReadLine(), out lengthOfGame);
                        if (correctInt && lengthOfGame > 0)
                            break;
                        else
                        {
                            Console.WriteLine("It was not a correct int.");
                        }
                    }
                    
                    chosenColors = new string[numberOfPlayers];
                    for (int i = 0; i < numberOfPlayers; i++)
                    {
                        Console.WriteLine("Choose Your color (print it).");
                        chosenColors[i] = Console.ReadLine();
                    }
                    
                }

                Player[] players = new Player[numberOfPlayers];
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    players[i] = new Player(chosenColors[i], numberOfFigures, lengthOfGame);
                }

                while (true)
                {
                    bool end = false;
                    for (int i = 0; i < numberOfPlayers; i++)
                    {
                        players[i].Play();
                    }

                    for (int i = 0; i < numberOfPlayers; i++)
                    {
                        if (players[i].CheckWin())
                            end = true;
                    }

                    if (end)
                        break;
                }
                Console.WriteLine("Do You want to play another game?");
                String another = Console.ReadLine().ToLower();
                if (another.Contains("yes"))
                {
                    Console.WriteLine("Great, prepare to a new game.");
                    firstGame = false;
                }
                else
                {
                    Console.WriteLine("Good, thank You for playing. Goodbye.");
                    break;
                }
            }
        }
    }
}