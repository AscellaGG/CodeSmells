using System;
using System.IO;
using System.Collections.Generic;
using CodeSmells.UI;
using CodeSmells.Statistics;
using CodeSmells.Game;

namespace MooGame
{
    class MainClass
    {
        // TODO: different statistics?

        public static void Main(string[] args)
        {
            IUI ui = new ConsoleIO();
            IStatistics statisticsController = new StatisticsController();
            IGame game = new Mastermind();

            GameController controller = new GameController(ui, statisticsController, game);
            controller.RunGameSession();
        }
    }
}