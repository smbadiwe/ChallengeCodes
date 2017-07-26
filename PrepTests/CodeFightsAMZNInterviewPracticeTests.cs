using System;
using System.Collections.Generic;
using System.Linq;
using Preps;
using NUnit.Framework;

namespace PrepTests
{
    [TestFixture]
    public class CodeFightsAMZNInterviewPracticeTests
    {
        [Test]
        public void totalScore()
        {
            var input = new[] { "5", "-2", "4", "Z", "X", "9", "+", "+" };
            var result = CodeFightsAMZNInterviewPractice.totalScore(input, 8);
            Assert.AreEqual(27, result);
        }

        [Test]
        public void pressingButtons_Test()
        {
            var input = "42";
            var expectedResult = new[] { "ga",
 "gb",
 "gc",
 "ha",
 "hb",
 "hc",
 "ia",
 "ib",
 "ic" };
            var result = CodeFightsAMZNInterviewPractice.pressingButtons(input);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }

        [Test]
        public void subsetSum_Test()
        {
            var input = new[] { 87, 56, 43, 91, 27, 65, 59, 36, 32, 51, 37, 28, 75, 7, 74 };
            var result = CodeFightsAMZNInterviewPractice.subsetSum(input);
            Assert.IsTrue(result);
        }

        [Test]
        public void findSubarrayBySum_Test()
        {
            var input = new[] { 4, 8, 9, 10, 3, 8 };
            var expectedResult = new[] { 1, 3 };
            var result = CodeFightsAMZNInterviewPractice.findSubarrayBySum(21, input);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }
        [Test]
        public void nextLarger_Test()
        {
            var input = new[] { 10, 3, 12, 4, 2, 9, 13, 0, 8, 11, 1, 7, 5, 6 };
            var expectedResult = new[] { 12, 12, 13, 9, 9, 13, -1, 8, 11, -1, 7, -1, 6, -1 };
            var result = CodeFightsAMZNInterviewPractice.nextLarger(input);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }
        [Test]
        public void stringPermutations_Test()
        {
            var input = "SABHD";
            var expectedResult = new[] {"ABDHS",
 "ABDSH",
 "ABHDS",
 "ABHSD",
 "ABSDH",
 "ABSHD",
 "ADBHS",
 "ADBSH",
 "ADHBS",
 "ADHSB",
 "ADSBH",
 "ADSHB",
 "AHBDS",
 "AHBSD",
 "AHDBS",
 "AHDSB",
 "AHSBD",
 "AHSDB",
 "ASBDH",
 "ASBHD",
 "ASDBH",
 "ASDHB",
 "ASHBD",
 "ASHDB",
 "BADHS",
 "BADSH",
 "BAHDS",
 "BAHSD",
 "BASDH",
 "BASHD",
 "BDAHS",
 "BDASH",
 "BDHAS",
 "BDHSA",
 "BDSAH",
 "BDSHA",
 "BHADS",
 "BHASD",
 "BHDAS",
 "BHDSA",
 "BHSAD",
 "BHSDA",
 "BSADH",
 "BSAHD",
 "BSDAH",
 "BSDHA",
 "BSHAD",
 "BSHDA",
 "DABHS",
 "DABSH",
 "DAHBS",
 "DAHSB",
 "DASBH",
 "DASHB",
 "DBAHS",
 "DBASH",
 "DBHAS",
 "DBHSA",
 "DBSAH",
 "DBSHA",
 "DHABS",
 "DHASB",
 "DHBAS",
 "DHBSA",
 "DHSAB",
 "DHSBA",
 "DSABH",
 "DSAHB",
 "DSBAH",
 "DSBHA",
 "DSHAB",
 "DSHBA",
 "HABDS",
 "HABSD",
 "HADBS",
 "HADSB",
 "HASBD",
 "HASDB",
 "HBADS",
 "HBASD",
 "HBDAS",
 "HBDSA",
 "HBSAD",
 "HBSDA",
 "HDABS",
 "HDASB",
 "HDBAS",
 "HDBSA",
 "HDSAB",
 "HDSBA",
 "HSABD",
 "HSADB",
 "HSBAD",
 "HSBDA",
 "HSDAB",
 "HSDBA",
 "SABDH",
 "SABHD",
 "SADBH",
 "SADHB",
 "SAHBD",
 "SAHDB",
 "SBADH",
 "SBAHD",
 "SBDAH",
 "SBDHA",
 "SBHAD",
 "SBHDA",
 "SDABH",
 "SDAHB",
 "SDBAH",
 "SDBHA",
 "SDHAB",
 "SDHBA",
 "SHABD",
 "SHADB",
 "SHBAD",
 "SHBDA",
 "SHDAB",
 "SHDBA" };
            var result = CodeFightsAMZNInterviewPractice.stringPermutations(input);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }
    }
}
