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
        private MooLogic moo;
        private IUI ui;
        private IStatistics statistics;

        private bool continuePlaying = true;
        private int numberOfGuesses;
        private string playerName;

        public GameController(IUI ui, IStatistics statistics, MooLogic moo)
        {
            this.ui = ui;
            this.statistics = statistics;
            this.moo = moo;
        }

        public void InitializeGame()
        {
            playerName = ui.GetPlayerName();

            while (continuePlaying)
            {
                RunNewGame();

                ui.DisplayFinalNumberOfGuesses(numberOfGuesses);

                statistics.AddPlayerToFile(playerName, numberOfGuesses);

                List<string> topList = statistics.GetTopList();
                ui.DisplayTopList(topList);

                continuePlaying = ui.GetContinuePlayingInput();
            }
        }

        private void RunNewGame()
        {
            numberOfGuesses = 0;
            string goal = moo.MakeGoal();

            ui.DisplayText("New game:");

            // Only for debug/practice purposes
            Console.WriteLine("For practice, number is: " + goal + "\n");

            string result = "";

            while (result != "BBBB,")
            {
                result = GetResult(goal);
                numberOfGuesses++;
            }            
        }

        private string GetResult(string goal)
        {
            string guess = ui.GetGuess();

            string newResult = moo.CheckGuess(goal, guess);

            ui.DisplayText(newResult);

            return newResult;
        }

    }
}
