using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.UI
{
    internal interface IUI
    {

        public string GetPlayerName();

        public void Exit();

        public string GetGuess();
    }
}
