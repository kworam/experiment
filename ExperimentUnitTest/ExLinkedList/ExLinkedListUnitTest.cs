using System.Collections.Generic;
using Experiment.ExLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExperimentUnitTest.ExLinkedListUnitTest
{
	[TestClass]
	public class ExLinkedListUnitTest
	{

		[TestMethod]
		public void FromEnumerableNull()
		{
			List<int> l = null;
			Assert.AreEqual(ExLinkedList<int>.FromEnumerable(l), null);
		}

		[TestMethod]
		public void FromEnumerableSingleton()
		{
			List<int> l = new List<int>() { 99 };
			Assert.IsTrue(
				ExLinkedList<int>.EqualsEnumerable(
					ExLinkedList<int>.FromEnumerable(l), l));
		}

		[TestMethod]
		public void FromEnumerableTwoOrMoreElements()
		{
			List<int> l = new List<int>() { 99, 33, 23, 22 };
			Assert.IsTrue(
				ExLinkedList<int>.EqualsEnumerable(
					ExLinkedList<int>.FromEnumerable(l), l));
		}

		[TestMethod]
		public void ReverseNullList()
		{
			List<int> l = null;
			Assert.IsTrue(ExLinkedList<int>.EqualsEnumerable(
				ExLinkedList<int>.Reverse(ExLinkedList<int>.FromEnumerable(l)), 
				l));
		}

		[TestMethod]
		public void ReverseSingletonList()
		{
			List<int> l = new List<int>() { 99 };
			Assert.IsTrue(ExLinkedList<int>.EqualsEnumerable(
				ExLinkedList<int>.Reverse(ExLinkedList<int>.FromEnumerable(l)),
				l));
		}

		[TestMethod]
		public void ReverseListTwoOrMore()
		{
			List<int> l = new List<int>() { 99, 33, 23, 667 };
			List<int> lReverse = new List<int>(l);
			lReverse.Reverse();
			Assert.IsTrue(ExLinkedList<int>.EqualsEnumerable(
				ExLinkedList<int>.Reverse(ExLinkedList<int>.FromEnumerable(l)),
				lReverse));
		}

        [TestMethod]
        public void ReverseNullListIterative()
        {
            List<int> l = null;
            Assert.IsTrue(ExLinkedList<int>.EqualsEnumerable(
                ExLinkedList<int>.ReverseIterative(ExLinkedList<int>.FromEnumerable(l)),
                l));
        }

        [TestMethod]
        public void ReverseSingletonListIterative()
        {
            List<int> l = new List<int>() { 99 };
            Assert.IsTrue(ExLinkedList<int>.EqualsEnumerable(
                ExLinkedList<int>.ReverseIterative(ExLinkedList<int>.FromEnumerable(l)),
                l));
        }

        [TestMethod]
        public void ReverseListTwoOrMoreIterative()
        {
            List<int> l = new List<int>() { 99, 33, 23, 667 };
            List<int> lReverse = new List<int>(l);
            lReverse.Reverse();
            Assert.IsTrue(ExLinkedList<int>.EqualsEnumerable(
                ExLinkedList<int>.ReverseIterative(ExLinkedList<int>.FromEnumerable(l)),
                lReverse));
        }
    }
}
