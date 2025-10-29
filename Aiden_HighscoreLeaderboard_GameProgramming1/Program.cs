using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Aiden_HighscoreLeaderboard_GameProgramming1
{
    internal class Program
    {
        static Random scoreGeneratorRnD = new Random();

        static int score;

        static string UserInput;
        static string path = "scores.txt";
        static String[] scoreDisplayList;

        static void DisplayScore()
        {
            Console.WriteLine("Your Score Is: " + score + "\n");
            Thread.Sleep(1000);
        }

        static void UserInitialInput()
        {
            Console.WriteLine("Please Input 3 Initials: ");
            Console.SetCursorPosition(25, 2);

            UserInput = Console.ReadLine();
            UserInput = UserInput.ToUpper();

            if (UserInput.Length != 3 || UserInput.Any(Char.IsDigit))
            {
                Console.Clear();
                DisplayScore();
                UserInitialInput();
            }
            else
            {
                File.AppendAllText(path, $"{score}: {UserInput},");
            }
        }

        static void DisplayHighscores()
        {
            Console.Clear();

            string ScoresFromFile = File.ReadAllText(path);
            scoreDisplayList = ScoresFromFile.Split(',');
            Array.Sort(scoreDisplayList);

            Console.WriteLine("Highscores:\n");

            for(int i = 1; i < scoreDisplayList.Length; i++)
            {

                Console.WriteLine($"{scoreDisplayList[i]}");

            }
        }

        static void Main(string[] args)
        {
            score = scoreGeneratorRnD.Next(1, 1001);

            DisplayScore();
            UserInitialInput();
            DisplayHighscores();

            Console.ReadKey();
        }
    }
}
