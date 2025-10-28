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

            if (UserInput.Length != 3)
            {
                Console.Clear();
                DisplayScore();
                UserInitialInput();
            }

            File.AppendAllText(path, $"{UserInput},{score} ");
        }

        static void DisplayHighscores()
        {
            Console.Clear();


            string ScoresFromFile = File.ReadAllText(path);

            scoreDisplayList = ScoresFromFile.Split(',');

            for(int i = 0; i < scoreDisplayList.Length; i ++)
            {
                Console.WriteLine(scoreDisplayList[i]);
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
