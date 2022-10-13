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
            bool aggressiveness = true;
            
            while (true)
            {
                bool newSettings;
                if (firstGame)
                {
                    newSettings = true;
                }
                else
                {
                    newSettings = GetBoolFromUser("Do You want to change settings?");
                }

                if (newSettings)
                {
                    numberOfPlayers = GetIntFromUser("Choose the number of players.");
                    numberOfFigures = GetIntFromUser("Choose the number of figures of every player.");
                    lengthOfGame = GetIntFromUser("Choose the lenght of the game.");
                    aggressiveness = GetBoolFromUser("Do You wish an aggressive map?");

                    chosenColors = new string[numberOfPlayers];
                    for (int i = 0; i < numberOfPlayers; i++)
                    {
                        Console.WriteLine("Choose Your color (print it).");
                        chosenColors[i] = Console.ReadLine();
                    }
                    
                }
                Map map;
                if (aggressiveness)
                    map = new AggressiveLinearMap(lengthOfGame);
                else
                    map = new PeacefulLinearMap(lengthOfGame);

                Player[] players = new Player[numberOfPlayers];
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    players[i] = new Player(chosenColors[i], numberOfFigures, lengthOfGame, map);
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

                bool newGame = GetBoolFromUser("Do You want to play another game?");
                if (newGame)
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

        private static int GetIntFromUser(string question)
        {
            int answer;
            while (true)
            {
                Console.WriteLine(question);
                bool correctInt = Int32.TryParse(Console.ReadLine(), out answer);
                if (correctInt && answer > 0)
                    break;
                else
                {
                    Console.WriteLine("It was not a correct int.");
                }
            }
            return answer;
        }

        private static bool GetBoolFromUser(string question)
        {
            bool answer;
            while (true)
            {
                Console.WriteLine(question);
                string input = Console.ReadLine().ToLower();
                if (input == "yes")
                {
                    answer = true;
                    break;
                }
                else if (input == "no")
                {
                    answer = false;
                    break;
                }
                else
                {
                    Console.WriteLine("It was not a correct answer.");
                }
            }
            return answer;
        }
    }
}