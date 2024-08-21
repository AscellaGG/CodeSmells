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
        private IGame _game;
        private IUI _ui;
        private IStatistics _statistics;

        private string playerName;

        public GameController(IUI ui, IStatistics statistics, IGame game)
        {
            _ui = ui;
            _statistics = statistics;
            _game = game;
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
            HandleGameStart();

            while (!_game.IsGameOver()) 
            {
                HandlePlayerInput();
            }

            HandleGameOver();
        }

        private void HandleGameStart()
        {
            _game.NewGame(new RandomGenerator());

            _ui.DisplayText("New game:");
        }

        private void HandlePlayerInput()
        {
            string guess = _ui.GetGuess();

            string newResult = _game.GetGuessResult(guess);

            _ui.DisplayText(newResult);

            _game.CheckAnswer(newResult);
        }

        private void HandleGameOver()
        {
            _ui.DisplayText("Correct, it took " + _game.GetNumberOfGuesses() + " guesses");

            _statistics.AddPlayerToFile(playerName, _game.GetNumberOfGuesses());

            _ui.DisplayTopList(_statistics.GetTopList());
        }

    }
}
 