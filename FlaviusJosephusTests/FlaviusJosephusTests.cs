using System;
using System.Collections.Generic;
using System.Linq;
using JosephusFlaviusTask;
using NUnit.Framework;

namespace FlaviusJosephusTests
{
    public class Tests
    {
        [TestCase(5,2,ExpectedResult = new int[]{2, 4, 1, 5, 3})]
        [TestCase(8,4,ExpectedResult = new int[]{4,8,5,2,1,3,7,6})]
        [TestCase(12,5, ExpectedResult = new int[]{5, 10, 3, 9, 4, 12, 8, 7, 11, 2, 6, 1})]
        [TestCase(2,5, ExpectedResult = new int[] {1, 2})]
        [TestCase(20,6,ExpectedResult = new int[]{6, 12, 18, 4, 11, 19, 7, 15, 3, 14, 5, 17, 10, 8, 2, 9, 16, 13, 1, 20})]
        public IEnumerable<int> FlaviusJosephusTask_WithAllValidParameters(int n, int k)
        {
            return FlaviusJosephusModel.ReturnSequence(n, k);
        }

        [Test]
        public void FlaviusJosephusTask_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => FlaviusJosephusModel.ReturnSequence(0, 5));
            Assert.Throws<ArgumentException>(() => FlaviusJosephusModel.ReturnSequence(5, 0));
        }
    }
}