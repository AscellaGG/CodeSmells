using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSmells.Game;

namespace CodeSmellsTests.Game.Mocks
{
    internal class MockRandomGenerator : IRandomGenerator
    {
        private readonly string _fixedGoal;

        public MockRandomGenerator(string fixedGoal)
        {
            _fixedGoal = fixedGoal;
        }

        public string GenerateGoal(int range, bool uniqueNumbers)
        {
            return _fixedGoal;
        }
    }
}
