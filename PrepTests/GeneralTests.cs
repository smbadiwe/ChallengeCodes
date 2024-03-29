﻿using NUnit.Framework;
using Preps;
using System;

namespace PrepTests
{
    public static class Vest
    {
        public static string Normalize(this decimal amount)
        {
            return (Math.Round(amount, 2) / 1.000000000000000000000000000000000m).ToString();
        }
    }

    [TestFixture]
    public class GeneralTests
    {
        [Test]
        public void TestDecimals()
        {
            decimal dd = (decimal)19.00;
            Assert.AreEqual("19", dd.Normalize());
            dd = (decimal)19.55;
            Assert.AreEqual("19.55", dd.Normalize());
            dd = (decimal)19.3456;
            Assert.AreEqual("19.35", dd.Normalize());
        }
        [Test]
        public void ReplaceWithGreatestElementFromRight()
        {
            var input = new[] { 16, 17, 4, 3, 5, 2 };
            var result = General.ReplaceWithGreatestElementFromRight(input);
            var assert = new[] { 17, 5, 5, 5, 2, -1 };
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(assert[i], result[i]);
            }
        }

        [Test]
        public void findMinimum_sorted_and_rotated_1()
        {
            var input = new[] { 3, 4, 5, 6, 7, 1, 2 };
            var result = General.findMinimum(input);
            Assert.AreEqual(1, result);
        }
        [Test]
        public void findMinimum_sorted_and_rotated_2()
        {
            var input = new[] { 6, 7, 1, 2, 3, 4, 5 };
            var result = General.findMinimum(input);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void findMinimum_sorted_but_not_rotated()
        {
            var input = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var result = General.findMinimum(input);
            Assert.AreEqual(1, result);
        }
    }
}
