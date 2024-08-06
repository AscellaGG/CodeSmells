using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodeSmells.Statistics
{
    class StatisticsController : IStatistics
    {
        private List<PlayerData> results = new List<PlayerData>();
        private StreamReader input = new StreamReader("result.txt");

        public void AddPlayer(string name, int numberOfGuesses)
        {
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(name + "#&#" + numberOfGuesses);
            output.Close();
        }

        private void LoadPlayers()
        {
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(guesses);
                }
            }
        }

        public void ShowTopList()
        {
            //string line;
            //while ((line = input.ReadLine()) != null)
            //{
            //    string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            //    string name = nameAndScore[0];
            //    int guesses = Convert.ToInt32(nameAndScore[1]);
            //    PlayerData pd = new PlayerData(name, guesses);
            //    int pos = results.IndexOf(pd);
            //    if (pos < 0)
            //    {
            //        results.Add(pd);
            //    }
            //    else
            //    {
            //        results[pos].Update(guesses);
            //    }
            //}

            results.Sort((p1, p2) => p1.AverageScore().CompareTo(p2.AverageScore()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in results)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.PlayerName, p.NumberOfGames, p.AverageScore()));
            }
            input.Close();
        }
    }
}
