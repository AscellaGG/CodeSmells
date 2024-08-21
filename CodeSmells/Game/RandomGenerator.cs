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

        public string GenerateGoal()
        {
            string goal = "";

            for (int i = 0; i < 4; i++)
            {
                int random = _random.Next(10);
                string randomDigit = "" + random;
                while (goal.Contains(randomDigit))
                {
                    random = _random.Next(10);
                    randomDigit = "" + random;
                }
                goal = goal + randomDigit;
            }

            return goal;
        }
    }
}
