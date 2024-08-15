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
            MooLogic moo = new MooLogic();

            // TODO: What to do with this? I want to avoid 3 arguments for controller...
            // Does singelton work? Only if the statistics are always for the same game.
            // If I wanna do VG stuff it no work?
            // StatisticsController statistics = new StatisticsController(); 

            GameController controller = new GameController(ui, statisticsController, moo);
            controller.InitializeGame();
        }
    }
}