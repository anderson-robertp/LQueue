namespace TestProject1;

using LQueue;
using NUnit.Framework;
using System;

public class Tests
{
    /// <summary>
    /// Test Purpose: Enqueue adds items to the back of the queue.
    /// The count should increase by one for each item added.
    /// Peek should return the item at the front of the queue.
    ///
    /// Expected Result:
    /// After enqueueing two items, peek should return 1 and the count should be 2.
    /// </summary>
    [Test]
    public void EnqueueAddItemsAndPeekReturnsFirstItem()
    {
        var queue = new LQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
    
        Assert.That(queue.Peek(), Is.EqualTo(1), "Peek should return 1.");
        Assert.That(queue.Count, Is.EqualTo(2), "Count should be 2.");
    }
    /// <summary>
    /// Test Purpose: Dequeue removes and returns the item at the front of the queue.
    ///
    /// Expected Result:
    /// Dequeue should return 1 and count should be 1.
    /// </summary>
    [Test]
    public void DequeueRemovesAndReturnsFirstItem()
    {
        var queue = new LQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
    
        Assert.That(queue.Dequeue(), Is.EqualTo(1), "Dequeue should return 1.");
        Assert.That(queue.Count, Is.EqualTo(1), "Count should be 1.");
    }
    
    /// <summary>
    /// Test Purpose: Contains returns true if the queue contains the specified item.
    ///
    /// Expected Result:
    /// Contains should return true if the queue contains 1 and false otherwise.
    /// </summary>
    [Test]
    public void ContainsReturnsTrueIfItemIsContained()
    {
        var queue = new LQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
    
        Assert.That(queue.Contains(1), Is.True, "Contains should return true.");
        Assert.That(queue.Contains(3), Is.False, "Contains should return false.");
    }
    
    /// <summary>
    /// Test Purpose: Dequeue should throw an exception if the queue is empty.
    ///
    /// Expected Result:
    /// Dequeue should throw an exception.
    /// </summary>
    [Test]
    public void DequeueThrowsExceptionIfQueueIsEmpty()
    {
        var queue = new LQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }
    
    /// <summary>
    /// Test Purpose: Peek should throw an exception if the queue is empty.
    ///
    /// Expected Result:
    /// Peek should throw an exception.
    /// </summary>
    [Test]
    public void PeekThrowsExceptionIfQueueIsEmpty()
    {
        var queue = new LQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }
}