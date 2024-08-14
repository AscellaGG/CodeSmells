using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.Statistics
{
    internal class PlayerData
    {
        public string PlayerName { get; private set; }
        public int NumberOfGames { get; private set; }
        int totalGuesses;


        public PlayerData(string name, int guesses)
        {
            PlayerName = name;
            NumberOfGames = 1;
            totalGuesses = guesses;
        }

        public void UpdatePlayer(int guesses)
        {
            totalGuesses += guesses;
            NumberOfGames++;
        }

        public double AverageScore()
        {
            return (double)totalGuesses / NumberOfGames;
        }


        public override bool Equals(object p)
        {
            return PlayerName.Equals(((PlayerData)p).PlayerName);
        }

        public override int GetHashCode()
        {
            return PlayerName.GetHashCode();
        }
    }
}

