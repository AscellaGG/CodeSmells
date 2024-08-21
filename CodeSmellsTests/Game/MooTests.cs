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
    public class MooTests
    {
        MooLogic moo;

        [TestInitialize()]
        public void TestInitialize()
        {
            MockRandomGenerator mockRandomGenerator = new MockRandomGenerator("1234");

            moo = new MooLogic();   

            moo.MakeGoal(mockRandomGenerator);
        }

        [TestMethod()]
        public void CheckGuessCorrectTest()
        {
            bool IsCorrect = false;
            string ResultOfGuess = moo.GetGuessResult("1234");

            if(ResultOfGuess == "BBBB,")
            {
                IsCorrect = true;
            }

            Assert.IsTrue(IsCorrect);
        }

        [TestMethod()]
        public void CheckGuessIncorrectTest() 
        {
            bool IsCorrect = false;
            string ResultOfGuess = moo.GetGuessResult("4321");

            if (ResultOfGuess == "BBBB,")
            {
                IsCorrect = true;
            }

            Assert.IsFalse(IsCorrect);
        }

        [TestMethod()]
        public void TestNumberOfGuesses()
        {
            string ResultOfGuess = moo.GetGuessResult("4321");
            ResultOfGuess = moo.GetGuessResult("2342");
            ResultOfGuess = moo.GetGuessResult("2154");

            Assert.AreEqual(3, moo.GetNumberOfGuesses());
        }

        [TestMethod()]
        public void TestIsGameOverFalse()
        {
            string ResultOfGuess = moo.GetGuessResult("4321");
            moo.CheckAnswer(ResultOfGuess);

            Assert.IsFalse(moo.IsGameOver());
        }

        [TestMethod()]
        public void TestIsGameOverTrue()
        {
            string ResultOfGuess = moo.GetGuessResult("1234");
            moo.CheckAnswer(ResultOfGuess);

            Assert.IsTrue(moo.IsGameOver());
        }
    }
}