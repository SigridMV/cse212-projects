using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario:  Adding multiple items with different priorities and dequeuing them
    // Expected Result:  Items are dequeued in the order of their priorities (highest to lowest)
    // Defect(s) Found: None so far
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Alice", 5);
        priorityQueue.Enqueue("Charlie", 3);

        Assert.AreEqual("Alice", priorityQueue.Dequeue());
        Assert.AreEqual("Charlie", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());

    }

    [TestMethod]
    // Scenario:   Attempting to dequeue from an empty priority queue
    // Expected Result:  InvalidOperationException is thrown
    // Defect(s) Found: None so far
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        // Act and Assert
        Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue(),
            "Dequeueing from an empty queue should throw an InvalidOperationException."
        );

    }

    [TestMethod]
    // Scenario: Adding items with the same priority and dequeuing them
    // Expected Result:  Items with the same priority are dequeued in the order they were added (FIFO for same priority)
    // Defect(s) Found: None
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Alice", 5);
        priorityQueue.Enqueue("Charlie", 3);

        // Act and Assert
        Assert.AreEqual("Alice", priorityQueue.Dequeue());
        Assert.AreEqual("Charlie", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());

    }

    [TestMethod]
    // Scenario: Enqueuing and dequeuing items alternately
    // Expected Result: The queue functions correctly, maintaining priority order as items are added and removed
    // Defect(s) Found: None so far
    public void TestPriorityQueue_4()
    {
        // Arrange
        var priorityQueue = new PriorityQueue();

        // Act and Assert
        priorityQueue.Enqueue("Bob", 2);
        Assert.AreEqual("Bob", priorityQueue.Dequeue()); // Immediately dequeued

        priorityQueue.Enqueue("Alice", 5);
        priorityQueue.Enqueue("Charlie", 3);
        Assert.AreEqual("Alice", priorityQueue.Dequeue()); // Highest priority
        Assert.AreEqual("Charlie", priorityQueue.Dequeue()); // Next highest priority

        // The queue should now be empty
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}


