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
    public class CodeFightsMSFTInterviewPracticeTests
    {
        [Test]
        public void higherVersion2_Test()
        {
            int result;
            result = CodeFightsMSFTInterviewPractice.higherVersion2("18546744073709551616.0", "18446744073709551616.01");
            Assert.AreEqual(result, 1);
        }

        [Test]
        public void multiplyTwoStrings_Test()
        {
            var result = CodeFightsMSFTInterviewPractice.multiplyTwoStrings("153", "46");
            Assert.AreEqual(result, "7038");
        }

        [Test]
        public void isPowerOfTwo2_Test()
        {
            var result = CodeFightsMSFTInterviewPractice.isPowerOfTwo2(13);
            Assert.AreEqual(result, false);
        }

        [Test]
        public void findTheNumbers_Test()
        {
            var result = CodeFightsMSFTInterviewPractice.findTheNumbers(new[] { 2,1,3,2 });
            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 3);
        }

        [Test]
        public void countWays_Test()
        {
            var result = CodeFightsMSFTInterviewPractice.CoinChangeProblem(new[] { 2, 4, 3, 5, 9 }, 9);
            Assert.AreEqual("(2 2 2 3)(2 2 5)(3 3 3)(9)", result);
        }

        [Test]
        public void integerToEnglishWords_Test()
        {
            string result;
            //result = CodeFightsMSFTInterviewPractice.integerToEnglishWords(29);
            //Assert.AreEqual("Twenty Nine", result);
            //result = CodeFightsMSFTInterviewPractice.integerToEnglishWords(123);
            //Assert.AreEqual("One Hundred Twenty Three", result);
            result = CodeFightsMSFTInterviewPractice.integerToEnglishWords(1234567);
            Assert.AreEqual("One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven", result);
        }
    }
}
