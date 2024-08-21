using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.Game
{
    public interface IRandomGenerator
    {
        string GenerateGoal(int range, bool uniqueNumbers);
    }
}
