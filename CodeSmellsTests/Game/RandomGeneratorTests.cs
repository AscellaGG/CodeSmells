using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeSmells.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.Game.Tests
{
    [TestClass()]
    public class RandomGeneratorTests
    {
        [TestMethod()]
        public void NoRepeatingNumbersTest()
        {
            RandomGenerator generator = new RandomGenerator();
            string goal = generator.GenerateGoal(10, true);
            bool hasMultiple = false;

            for (int i = 0; i < goal.Length; i++) 
            {
                for (int j = i +1; j < goal.Length; j++) 
                {
                    if (goal[i] == goal[j])
                    {
                        hasMultiple = true;
                    }

                }
            }

            Assert.IsFalse(hasMultiple);
        }
    }
}