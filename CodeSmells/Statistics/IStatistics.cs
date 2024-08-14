using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.Statistics
{
    internal interface IStatistics
    {
        public void AddPlayerToFile(string name, int numberOfGuesses);
        public void ShowTopList();
    }
}
