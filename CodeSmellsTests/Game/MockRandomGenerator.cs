using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeSmells.Game
{
    internal class MockRandomGenerator : IRandomGenerator
    {
        private readonly string _fixedGoal;

        public MockRandomGenerator(string fixedGoal)
        {
            _fixedGoal = fixedGoal; 
        }

        public string GenerateGoal()
        {
            return _fixedGoal;
        }
    }
}
