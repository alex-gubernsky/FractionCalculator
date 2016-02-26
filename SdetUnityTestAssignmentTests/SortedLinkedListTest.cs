using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SdetUnityTestAssignment.SortedLinkedList;

namespace SdetUnityTestAssignmentTests
{
    [TestClass]
    public class SortedLinkedListTest
    {
        [TestMethod]
        public void EmptyListTest()
        {
            SortedLinkedList list = new SortedLinkedList();
            var iterator = list.GetIterator();
            Assert.IsFalse(iterator.HasNext());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void EmptyListExceptionTest()
        {
            SortedLinkedList list = new SortedLinkedList();
            var iterator = list.GetIterator();
            iterator.Next();
        }

        [TestMethod]
        public void EmptyListCountTest()
        {
            SortedLinkedList list = new SortedLinkedList();
            Assert.IsTrue(list.Count.Equals(0));
        }

        [TestMethod]
        public void ListCountTest()
        {
            const int count = 5;
            SortedLinkedList list = new SortedLinkedList();
            for (int i = 0; i < count; i++)
                list.Add(i);
            Assert.IsTrue(list.Count.Equals(count));
        }

        [TestMethod]
        public void OneValueInListTest()
        {
            const int val = 5;
            SortedLinkedList list = new SortedLinkedList();
            list.Add(val);

            var iterator = list.GetIterator();
            Assert.IsTrue(iterator.Next().Equals(val));
        }

        [TestMethod]
        public void MinValueIsInHeadTest()
        {
            SortedLinkedList list = new SortedLinkedList();
            list.Add(10);
            list.Add(-100);
            list.Add(1);
            list.Add(-10);
            list.Add(5);

            var iterator = list.GetIterator();
            Assert.IsTrue(iterator.Next().Equals(-100));
        }

        [TestMethod]
        public void MaxNumbersTest()
        {
            SortedLinkedList list = new SortedLinkedList();
            list.Add(Int32.MaxValue);
            list.Add(Int32.MinValue);

            var iterator = list.GetIterator();
            Assert.IsTrue(iterator.Next().Equals(Int32.MinValue));
        }

        [TestMethod]
        public void SortTest()
        {
            int[] sourceArray = new[] { 10, -100, 1, -10, 0, Int32.MaxValue, Int32.MinValue };
            int[] sortedArray = new[] { Int32.MinValue, -100, -10, 0, 1, 10, Int32.MaxValue };

            SortedLinkedList list = new SortedLinkedList();
            for (int i = 0; i < sourceArray.Length; i++)
            {
                list.Add(sourceArray[i]);
            }

            var iterator = list.GetIterator();
            int j = 0;
            while (iterator.HasNext())
            {
                Assert.IsTrue(iterator.Next().Equals(sortedArray[j]));
                j++;
            }
        }
    }
}
