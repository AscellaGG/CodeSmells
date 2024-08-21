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
        private MooLogic _moo;
        private IUI _ui;
        private IStatistics _statistics;

        private string playerName;

        public GameController(IUI ui, IStatistics statistics)
        {
            _ui = ui;
            _statistics = statistics;
        }

        public void RunGameSession()
        {
            playerName = _ui.GetPlayerName();

            bool continuePlaying = true;

            while (continuePlaying)
            {
                RunNewGame();

                continuePlaying = _ui.GetContinuePlayingInput();
            }
        }

        private void RunNewGame()
        {
            _moo = new MooLogic();

            HandleGameStart();

            while (!_moo.IsGameOver()) 
            {
                HandlePlayerInput();
            }

            HandleGameOver();
        }

        private void HandleGameStart()
        {
            _moo.MakeGoal(new RandomGenerator());

            _ui.DisplayText("New game:");
        }

        private void HandlePlayerInput()
        {
            string guess = _ui.GetGuess();

            string newResult = _moo.GetGuessResult(guess);

            _ui.DisplayText(newResult);

            _moo.CheckAnswer(newResult);
        }

        private void HandleGameOver()
        {
            _ui.DisplayText("Correct, it took " + _moo.GetNumberOfGuesses() + " guesses");

            _statistics.AddPlayerToFile(playerName, _moo.GetNumberOfGuesses());

            _ui.DisplayTopList(_statistics.GetTopList());
        }

    }
}
 