using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CodeSmells.UI;

namespace CodeSmells
{
    class GameController
    {
        private Moo moo;
        private IUI ui;

        public GameController(Moo moo, IUI ui) 
        {
            this.ui = ui;
            this.moo = moo;
        }
        
        public void Run()
        {
            bool playOn = true;

            Console.WriteLine("Enter your user name:\n");
            string name = Console.ReadLine();

            while (playOn)
            {
                string goal = moo.MakeGoal();                

                Console.WriteLine("New game:\n");
                Console.WriteLine("For practice, number is: " + goal + "\n");

                string guess = ui.GetGuess();

                int nGuess = 1;
                string result = moo.CheckGuess(goal, guess);
                Console.WriteLine(result + "\n");

                while (result != "BBBB,")
                {
                    nGuess++;
                    guess = Console.ReadLine();
                    Console.WriteLine(guess + "\n");
                    result = moo.CheckGuess(goal, guess);
                    Console.WriteLine(result + "\n");
                }

                AddPlayerToFile(name, nGuess);
                //showTopList();
                Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
                }
            }
        }

        public void AddPlayerToFile(string name, int numberOfGuesses)
        {
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(name + "#&#" + numberOfGuesses);
            output.Close();
        }

        
    }
}
