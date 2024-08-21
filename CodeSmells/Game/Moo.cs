﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.Game
{
    public class Moo : IGame
    {
        public bool IsGameOver { get; private set; } = false;
        public int NumberOfGuesses { get; private set; } = 0;

        private string goal = "";

        public void NewGame(IRandomGenerator randomGenerator)
        {
            IsGameOver = false;
            NumberOfGuesses = 0;

            goal = randomGenerator.GenerateGoal(10, true);

            // Only for debug/practice purposes
            Console.WriteLine("For practice, number is: " + goal + "\n");
        }

        public string GetGuessResult(string guess)
        {
            int cows = 0, bulls = 0;

            guess += "    ";     // if player entered less than 4 chars

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }

            NumberOfGuesses++;

            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }

        public void CheckAnswer(string guessResult)
        {
            if (guessResult == "BBBB,")
            {
                IsGameOver = true;
            } else
            {
                IsGameOver = false;
            }
        }
    }
}
