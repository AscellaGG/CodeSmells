using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.UI
{
    internal interface IUI
    {
        public void DisplayStartText();

        public string GetPlayerName();
 
        public string GetGuess();

        public void DisplayResult(string result);

        public void DisplayFinalNumberOfGuesses(int guesses);

        public string AskToQuit();

    }
}
