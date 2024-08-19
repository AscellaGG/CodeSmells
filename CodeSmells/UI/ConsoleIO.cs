using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.UI
{
    internal class ConsoleIO : IUI
    {
        public void DisplayText(string text)
        {
            Console.WriteLine(text + "\n"); 
        }

        public string GetPlayerName()
        {
            Console.WriteLine("Enter your user name:\n");
            string name = Console.ReadLine();
            return name;
        }


        public string GetGuess()
        {
            string guess = Console.ReadLine();
            Console.WriteLine(guess + "\n");
            return guess;
        }

        public void DisplayTopList(List<string> topList)
        {
            Console.WriteLine("Player   Games  Average");
            foreach (string line in topList) 
            {
                Console.WriteLine(line);
            }
        }

        public bool GetContinuePlayingInput()
        {
            Console.WriteLine("Continue?");
            string answer = Console.ReadLine();

            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
