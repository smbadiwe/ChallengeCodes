using System;
using System.Collections.Generic;
using System.Linq;
using Preps;
using NUnit.Framework;

namespace PrepTests
{
   [TestFixture]
    public class SortingsTest
    {
        [Test]
        public void BubbleSort()
        {
            var arr = new[] { 7, 5, 2, 4, 3, 9 };
            Sortings.BubbleSort(arr);
            Assert.AreEqual(2, arr[0]);
            Assert.AreEqual(3, arr[1]);
            Assert.AreEqual(4, arr[2]);
            Assert.AreEqual(5, arr[3]);
            Assert.AreEqual(7, arr[4]);
            Assert.AreEqual(9, arr[5]);
        }

        [Test]
        public void SelectionSort()
        {
            var arr = new[] { 7, 5, 2, 4, 3, 9 };
            Sortings.SelectionSort(arr);
            Assert.AreEqual(2, arr[0]);
            Assert.AreEqual(3, arr[1]);
            Assert.AreEqual(4, arr[2]);
            Assert.AreEqual(5, arr[3]);
            Assert.AreEqual(7, arr[4]);
            Assert.AreEqual(9, arr[5]);
        }

        [Test]
        public void MergeSort()
        {
            var arr = new[] { 7, 5, 2, 4, 3, 9 };
            Sortings.MergeSort(arr);
            Assert.AreEqual(2, arr[0]);
            Assert.AreEqual(3, arr[1]);
            Assert.AreEqual(4, arr[2]);
            Assert.AreEqual(5, arr[3]);
            Assert.AreEqual(7, arr[4]);
            Assert.AreEqual(9, arr[5]);
        }

        [Test]
        public void QuickSort()
        {
            var arr = new[] { 7, 5, 2, 4, 3, 9 };
            Sortings.QuickSort(arr);
            Assert.AreEqual(2, arr[0]);
            Assert.AreEqual(3, arr[1]);
            Assert.AreEqual(4, arr[2]);
            Assert.AreEqual(5, arr[3]);
            Assert.AreEqual(7, arr[4]);
            Assert.AreEqual(9, arr[5]);
        }

        [Test]
        public void HeapSort()
        {
            var arr = new[] { 7, 5, 2, 4, 3, 9 };
            Sortings.HeapSort(arr);
            Assert.AreEqual(2, arr[0]);
            Assert.AreEqual(3, arr[1]);
            Assert.AreEqual(4, arr[2]);
            Assert.AreEqual(5, arr[3]);
            Assert.AreEqual(7, arr[4]);
            Assert.AreEqual(9, arr[5]);
        }
    }
}
