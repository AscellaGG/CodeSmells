using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.UI
{
    internal interface IUI
    {
        public void DisplayText(string text);

        public string GetPlayerName();
 
        public string GetGuess();
        
        public void DisplayTopList(List<string> topList);

        public bool GetContinuePlayingInput();


    }
}
