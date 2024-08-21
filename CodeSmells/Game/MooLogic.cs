using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.Game
{
    public class MooLogic
    {
        private bool isGameOver = false;
        private int numberOfGuesses = 0;
        private string goal = "";

        public bool IsGameOver() { return isGameOver; }

        public int GetNumberOfGuesses() { return numberOfGuesses; }

        public void MakeGoal(IRandomGenerator randomGenerator)
        {
            goal = randomGenerator.GenerateGoal();

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

            numberOfGuesses++;

            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }

        public void CheckAnswer(string guessResult)
        {
            if (guessResult == "BBBB,")
            {
                isGameOver = true;
            } else
            {
                isGameOver = false;
            }

        }
    }
}
