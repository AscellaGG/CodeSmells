using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.UI
{
    internal class ConsoleIO : IUI
    {
        public void DisplayStartText()
        {
            Console.WriteLine("New game:\n");
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

        public void DisplayResult(string result)
        {
            Console.WriteLine(result + "\n");
        }

        public void DisplayFinalNumberOfGuesses(int guesses)
        {
            Console.WriteLine("Correct, it took " + guesses + " guesses");
        }

        public string AskToQuit()
        {
            Console.WriteLine("Continue?");
            string answer = Console.ReadLine();
            return answer;
        }

    }
}
