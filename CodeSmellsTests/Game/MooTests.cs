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
        Moo moo;

        [TestInitialize()]
        public void TestInitialize()
        {
            moo = new Moo();    
        }

        [TestMethod()]
        public void MakeGoalTest()
        {
            string goal = moo.MakeGoal();
            int numberOfGoalDigits = 0;

            for (int i = 0; i < goal.Length; i++)
            {
                numberOfGoalDigits++;
            }

            Assert.AreEqual(4,numberOfGoalDigits);
        }

        [TestMethod()]
        public void CheckGuessCorrectTest()
        {
            string ResultOfGuess = moo.CheckGuess("1234", "1234");
            bool IsCorrect = false;

            if(ResultOfGuess == "BBBB,")
            {
                IsCorrect = true;
            }


            Assert.IsTrue(IsCorrect);
        }

        [TestMethod()]
        public void CheckGuessIncorrectTest() 
        {
            string ResultOfGuess = moo.CheckGuess("1234", "4321");
            bool IsCorrect = false;

            if (ResultOfGuess == "BBBB,")
            {
                IsCorrect = true;
            }

            Assert.IsFalse(IsCorrect);
        }
    }
}