using NUnit.Framework;
using Preps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepTests
{
    [TestFixture]
    public class CodeFightsArcadeTests
    {
        [Test]
        public void depositProfit_Test()
        {
            int deposit = 100, rate = 20, threshold = 170;
            var result = CodeFightsArcade.depositProfit(deposit, rate, threshold);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void alphabeticShift_Test()
        {
            var input = "crazy";
            var result = CodeFightsArcade.alphabeticShift(input);
            Assert.AreEqual("dsbaz", result);
        }
        [Test]
        public void minesweeper_Test()
        {
            var input = new[] {
                new[] { true,false,false },
                new[] { false,true,false },
                new[] { false,false,false },
            };
            System.Text.RegularExpressions.Regex.IsMatch("", "^[A-Za-z0-9_]$");
            var result = CodeFightsArcade.minesweeper(input);
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(3, result[0].Length);
        }

        [Test]
        public void boxBlur_Test()
        {
            var input = new[] {
                new[] { 36,0,18,9 },
                new[] { 27,54,9,0 },
                new[] { 81,63,72,45 },
            };

            var result = CodeFightsArcade.boxBlur(input);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(2, result[0].Length);
        }
    }
}
