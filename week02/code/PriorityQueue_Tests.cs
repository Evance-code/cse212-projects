using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Week02Tests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void TestPriorityQueue_1()
        {
            var priorityQueue = new PriorityQueue();

            priorityQueue.Enqueue("Low", 1);
            priorityQueue.Enqueue("Medium", 5);
            priorityQueue.Enqueue("High", 10);

            var result = priorityQueue.Dequeue();

            Assert.AreEqual("High", result);
        }

        [TestMethod]
        public void TestPriorityQueue_2()
        {
            var priorityQueue = new PriorityQueue();

            priorityQueue.Enqueue("First", 5);
            priorityQueue.Enqueue("Second", 5);
            priorityQueue.Enqueue("Third", 5);

            var result = priorityQueue.Dequeue();

            // FIFO for equal priority (first item added with highest priority)
            Assert.AreEqual("First", result);
        }

        [TestMethod]
        public void TestPriorityQueue_EmptyQueue()
        {
            var priorityQueue = new PriorityQueue();

            var exception = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                priorityQueue.Dequeue();
            });

            Assert.AreEqual("The queue is empty.", exception.Message);
        }

        [TestMethod]
        public void TestPriorityQueue_MultipleDequeues()
        {
            var priorityQueue = new PriorityQueue();

            priorityQueue.Enqueue("Low", 1);
            priorityQueue.Enqueue("Medium", 5);
            priorityQueue.Enqueue("High", 10);

            Assert.AreEqual("High", priorityQueue.Dequeue());
            Assert.AreEqual("Medium", priorityQueue.Dequeue());
            Assert.AreEqual("Low", priorityQueue.Dequeue());

            var exception = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                priorityQueue.Dequeue();
            });
            Assert.AreEqual("The queue is empty.", exception.Message);
        }
    }
}
