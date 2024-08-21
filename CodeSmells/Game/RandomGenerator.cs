using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.Game
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random _random;

        public RandomGenerator() 
        {
            _random = new Random();
        }

        public string GenerateGoal(int range, bool uniqueNumbers)
        {
            string goal = "";

            for (int i = 0; i < 4; i++)
            {
                int random = _random.Next(range);
                string randomDigit = "" + random;

                if (uniqueNumbers)
                {
                    while (goal.Contains(randomDigit))
                    {
                        random = _random.Next(range);
                        randomDigit = "" + random;
                    }
                }

                goal = goal + randomDigit;
            }

            return goal;
        }
    }
}
