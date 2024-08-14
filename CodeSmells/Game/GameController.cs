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

        public GameController(IUI ui, IStatistics statistics, MooLogic moo)
        {
            this.ui = ui;
            this.statistics = statistics;
            this.moo = moo;
        }

        public void Run() // TODO: Call it Initialize?
        {
            string playerName = ui.GetPlayerName();

            while (continuePlaying)
            {
                PlayGame(playerName);
            }
        }

        private void PlayGame(string playerName)
        {
            numberOfGuesses = 0;
            string goal = moo.MakeGoal();

            ui.DisplayStartText();

            // Only for debug/practice purposes
            Console.WriteLine("For practice, number is: " + goal + "\n");

            string result = "";

            while (result != "BBBB,")
            {
                result = GetResult(goal);
                numberOfGuesses++;
            }

            statistics.AddPlayerToFile(playerName, numberOfGuesses);
            statistics.ShowTopList();

            ui.DisplayFinalNumberOfGuesses(numberOfGuesses);
            EndGame();
        }

        private string GetResult(string goal)
        {
            string guess = ui.GetGuess();

            string newResult = moo.CheckGuess(goal, guess);

            ui.DisplayResult(newResult);

            return newResult;
        }

        private void EndGame() // TODO: maybe wrap all of playgame in this and move that shit out? EndGame() seems confusing when its only asking IF you want to end the game?
        {
            string answer = ui.AskToQuit();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                continuePlaying = false;
            }
        }
    }
}
