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
    public class PlayProgramsTests
    {
        [Test]
        public void TicTacToe()
        {
            var game = new TicTacToe();
            var result = Assert.Throws<ArithmeticException>(() => game.Start());
            Assert.True("Draw" == result.Message ||
                "Winner: X" == result.Message ||
                "Winner: O" == result.Message);
        }

        [Test]
        public void SwapInPlace()
        {
            int[] arr = new[] { 1, 2, 3, 4, 5, 6 };
            PlayPrograms.SwapInPlace(arr, 2, 5, false);
            Assert.AreEqual(6, arr[2]);
            Assert.AreEqual(3, arr[5]);
        }
        [Test]
        public void Add()
        {
            var result = PlayPrograms.Add(48, 48);
            Assert.AreEqual(96, result);
            result = PlayPrograms.Add(18, 48);
            Assert.AreEqual(66, result);
            result = PlayPrograms.Add(1, 48);
            Assert.AreEqual(49, result);
            result = PlayPrograms.Add(17, 11);
            Assert.AreEqual(28, result);
            result = PlayPrograms.Add(0, 11);
            Assert.AreEqual(11, result);
        }

        [Test]
        public void GCD()
        {
            var result = PlayPrograms.GCD(48, 48);
            Assert.AreEqual(48, result);
            result = PlayPrograms.GCD(18, 48);
            Assert.AreEqual(6, result);
            result = PlayPrograms.GCD(1, 48);
            Assert.AreEqual(1, result);
            result = PlayPrograms.GCD(17, 11);
            Assert.AreEqual(1, result);
            result = PlayPrograms.GCD(0, 11);
            Assert.AreEqual(11, result);
        }
        [Test]
        public void IsPrime()
        {
            var result = PlayPrograms.isPrime(991);
            Assert.IsTrue(result);
            result = PlayPrograms.isPrime(59);
            Assert.IsTrue(result);
            result = PlayPrograms.isPrime(25);
            Assert.IsFalse(result);
            result = PlayPrograms.isPrime(15);
            Assert.IsFalse(result);
            result = PlayPrograms.isPrime(17);
            Assert.IsTrue(result);
        }
    }
}
