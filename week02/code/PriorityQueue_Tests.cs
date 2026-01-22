using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Week02Tests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        // Scenario: Add elements with different priorities and dequeue once
        // Expected Result: The element with the highest priority ("High") is dequeued first
        // Test Result: Passed
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
        // Scenario: Add multiple elements with equal priority and dequeue once
        // Expected Result: FIFO behavior for elements with equal priority; "First" should be dequeued first
        // Test Result: Passed
        public void TestPriorityQueue_2()
        {
            var priorityQueue = new PriorityQueue();

            priorityQueue.Enqueue("First", 5);
            priorityQueue.Enqueue("Second", 5);
            priorityQueue.Enqueue("Third", 5);

            var result = priorityQueue.Dequeue();

            Assert.AreEqual("First", result);
        }

        [TestMethod]
        // Scenario: Dequeue from an empty queue
        // Expected Result: InvalidOperationException with message "The queue is empty."
        // Test Result: Passed
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
        // Scenario: Add multiple elements and dequeue all, checking order
        // Expected Result: Dequeue order should be "High", "Medium", "Low" and exception thrown after queue is empty
        // Test Result: Passed
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
