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

        private string playerName;

        public GameController(IUI ui, IStatistics statistics)
        {
            this.ui = ui;
            this.statistics = statistics;
            moo = new MooLogic();
        }

        public void RunGameSession()
        {
            playerName = ui.GetPlayerName();

            bool continuePlaying = true;

            while (continuePlaying)
            {
                RunNewGame();

                continuePlaying = ui.GetContinuePlayingInput();
            }
        }

        private void RunNewGame()
        {
            HandleGameStart();

            while (!moo.IsGameOver()) 
            {
                HandlePlayerInput();
            }

            HandleGameOver();
        }

        private void HandleGameStart()
        {
            moo.MakeGoal();

            ui.DisplayText("New game:");
        }

        private void HandlePlayerInput()
        {
            string guess = ui.GetGuess();

            string newResult = moo.GetGuessResult(guess);

            ui.DisplayText(newResult);

            moo.CheckAnswer(newResult);
        }

        private void HandleGameOver()
        {
            ui.DisplayText("Correct, it took " + moo.GetNumberOfGuesses() + " guesses");

            statistics.AddPlayerToFile(playerName, moo.GetNumberOfGuesses());

            ui.DisplayTopList(statistics.GetTopList());
        }

    }
}
 