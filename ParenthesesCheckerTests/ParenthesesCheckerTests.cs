using System;
using System.Collections.Generic;
using NUnit.Framework;
using ParenthesesTask;

namespace ParenthesesCheckerTests
{
    public class Tests
    {
        [TestCase("", ExpectedResult = true)]
        [TestCase("((hello))..({{[...]}})", ExpectedResult = true)]
        [TestCase("[[((.....)])]", ExpectedResult = false)]
        [TestCase("(x +(x-y) * (x[1] + x[2]))", ExpectedResult = true)]
        [TestCase("[[[[((({{{9}}})))]]]]", ExpectedResult = true)]
        [TestCase("((hello))..({[...]}})", ExpectedResult = false)]
        public bool ParenthesesCheckerTests_WithAllValidParameters(string text)
        {
            return new ParenthesesTask.ParenthesesChecker().CheckParentheses(text);
        }

        [TestCase("<12(345))>", ExpectedResult = true)]
        [TestCase("((asb)adc<>)[[[9]]]", ExpectedResult = true)]
        public bool ParenthesesCheckerTests_WithCustomParentheses(string text)
        {
            return new ParenthesesChecker(new Dictionary<char, char>
            {
                {'[', ']'},
                {'<', '>'},
            }).CheckParentheses(text);
        }

        public void ParenthesesCheckerTests_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ParenthesesChecker().CheckParentheses(null));
        }
    }
}