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

            // TODO: What to do with this? I want to avoid 3 arguments for controller...
            // Does singelton work? Only if the statistics are always for the same game.
            // If I wanna do VG stuff it no work?
            // StatisticsController statistics = new StatisticsController(); 

            // TODO: Online research to reference in text
            // TODO: Felhantering
            // TODO: Testing
            // TODO: Comments?
            // TODO: add refrences for testing in documentation

            GameController controller = new GameController(ui, statisticsController);
            controller.RunGameSession();
        }
    }
}