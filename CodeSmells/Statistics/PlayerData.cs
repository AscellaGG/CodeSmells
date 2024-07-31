﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.Statistics
{
    internal class PlayerData
    {
        public string Name { get; private set; }
        public int NGames { get; private set; }
        int totalGuess;


        public PlayerData(string name, int guesses)
        {
            Name = name;
            NGames = 1;
            totalGuess = guesses;
        }

        public void Update(int guesses)
        {
            totalGuess += guesses;
            NGames++;
        }

        public double Average()
        {
            return (double)totalGuess / NGames;
        }


        public override bool Equals(object p)
        {
            return Name.Equals(((PlayerData)p).Name);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

