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

        public static void Main(string[] args)
        {
            IUI ui = new ConsoleIO();
            IStatistics statisticsController = new StatisticsController();

            GameController controller = new GameController(ui, statisticsController);
            controller.RunGameSession();
        }
    }
}