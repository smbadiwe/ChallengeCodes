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
    public class CodeFightsArcade2Tests
    {
        [Test]
        public void buildPalindrome()
        {
            CodeFightsArcade2.buildPalindrome("ababab");
        }
    }
}
