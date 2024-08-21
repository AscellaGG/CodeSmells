using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodeSmells.Statistics
{
    public class StatisticsController : IStatistics
    {

        public void AddPlayerToFile(string name, int numberOfGuesses)
        {
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(name + "#&#" + numberOfGuesses);
            output.Close();
        }

        private List<PlayerData> LoadPlayersFromFile()
        {
            List<PlayerData> results = new List<PlayerData>();
            StreamReader input = new StreamReader("result.txt");
            string line;

            while ((line = input.ReadLine()) != null)
            {
                PlayerData pd = CreatePlayerDataFromString(line);

                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].UpdatePlayer(pd.totalGuesses);
                }
            }
            input.Close();

            return results;
        }

        private PlayerData CreatePlayerDataFromString(string playerString)
        {
            string[] nameAndScore = playerString.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string playerName = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            PlayerData pd = new PlayerData(playerName, guesses);

            return pd;
        } 

        public List<string> GetTopList()
        {
            List<PlayerData> players = LoadPlayersFromFile();
            players.Sort((p1, p2) => p1.AverageScore().CompareTo(p2.AverageScore()));

            List<string> topList = [];
            
            foreach (PlayerData player in players)
            {
                topList.Add(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.playerName, player.numberOfGames, player.AverageScore()));
            }

            return topList;
        }
    }
}
