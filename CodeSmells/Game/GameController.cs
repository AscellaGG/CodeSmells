using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CodeSmells.Statistics;
using CodeSmells.UI;

namespace CodeSmells.Game
{
    class GameController
    {
        private Moo moo;
        private IUI ui;
        private IStatistics statistics;

        public GameController(IUI ui, IStatistics statistics, Moo moo)
        {
            this.ui = ui;
            this.statistics = statistics;
            this.moo = moo;
        }

        public void Run()
        {
            bool playOn = true;

            string playerName = ui.GetPlayerName();

            while (playOn)
            {
                string goal = moo.MakeGoal();

                Console.WriteLine("New game:\n");
                Console.WriteLine("For practice, number is: " + goal + "\n");

                int numberOfGuesses = 0;
                string result = "";

                while (result != "BBBB,")
                {
                   result = GetResult(goal);
                   numberOfGuesses++;
                }

                //AddPlayerToFile(playerName, numberOfGuesses);
                //showTopList();
                Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
                }
            }
        }

        public void StartGame()
        {

        }

        public string GetResult(string goal)
        {
            string guess = ui.GetGuess();
            Console.WriteLine(guess + "\n");

            string newResult = moo.CheckGuess(goal, guess);
            Console.WriteLine(newResult + "\n");

            return newResult;
        }


    }
}
