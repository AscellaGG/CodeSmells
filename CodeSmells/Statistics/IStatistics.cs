using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.Statistics
{
    interface IStatistics
    {
        public void AddPlayer() { }
        public void ShowTopList() { }
        private void LoadPlayers() { }
    }
}
