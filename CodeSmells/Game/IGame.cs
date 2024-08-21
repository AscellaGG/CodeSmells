﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.Game
{
    public interface IGame
    {
        public bool IsGameOver {  get; }
        public int NumberOfGuesses { get; }

        public void NewGame(IRandomGenerator randomGenerator);
        //public void MakeGoal(IRandomGenerator randomGenerator);

        public string GetGuessResult(string guess);

        public void CheckAnswer(string guessResult);
    }
}
