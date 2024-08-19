using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.Statistics
{
    internal class PlayerData
    {
        public string playerName { get; private set; }
        public int numberOfGames { get; private set; }
        public int totalGuesses;


        public PlayerData(string name, int guesses)
        {
            playerName = name;
            numberOfGames = 1;
            totalGuesses = guesses;
        }

        public void UpdatePlayer(int guesses)
        {
            totalGuesses += guesses;
            numberOfGames++;
        }

        public double AverageScore()
        {
            return (double)totalGuesses / numberOfGames;
        }


        public override bool Equals(object p)
        {
            return playerName.Equals(((PlayerData)p).playerName);
        }

        public override int GetHashCode()
        {
            return playerName.GetHashCode();
        }
    }
}

