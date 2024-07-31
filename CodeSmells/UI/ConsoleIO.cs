using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.UI
{
    internal class ConsoleIO : IUI
    {
        public void Exit()
        {
            Environment.Exit(0);
        }

        //return guess as a string for gamecontroller to check?
        public string GetGuess()
        {
            string guess = Console.ReadLine();
            return guess;

            //int nGuess = 1;
            //string bbcc = checkBC(goal, guess);
            //Console.WriteLine(bbcc + "\n");
            //while (bbcc != "BBBB,")
            //{
            //    nGuess++;
            //    guess = Console.ReadLine();
            //    Console.WriteLine(guess + "\n");
            //    bbcc = checkBC(goal, guess);
            //    Console.WriteLine(bbcc + "\n");

        }

        public void StartGame()
        {
            Console.WriteLine("Enter your user name:\n");
            string name = Console.ReadLine();
        }
    }
}
