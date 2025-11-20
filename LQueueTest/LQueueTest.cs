namespace TestProject1;

using LQueue;
using NUnit.Framework;
using System;

public class Tests
{
    // Enqueue should add an item to the end of the queue
    // and increase the count by one.
    // Peek should return the item at the front of the queue.
    [Test]
    public void EnqueueAddItemsAndPeekReturnsFirstItem()
    {
        var queue = new LQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
    
        Assert.That(queue.Peek(), Is.EqualTo(1), "Peek should return 1.");
        Assert.That(queue.Count, Is.EqualTo(2), "Count should be 2.");
    }
    // Dequeue should remove and return the item at the front of the queue.
    // Count should decrease by one.
    [Test]
    public void DequeueRemovesAndReturnsFirstItem()
    {
        var queue = new LQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
    
        Assert.That(queue.Dequeue(), Is.EqualTo(1), "Dequeue should return 1.");
        Assert.That(queue.Count, Is.EqualTo(1), "Count should be 1.");
    }
    // Contains should return true if the queue contains the specified item.
    [Test]
    public void ContainsReturnsTrueIfItemIsContained()
    {
        var queue = new LQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
    
        Assert.That(queue.Contains(1), Is.True, "Contains should return true.");
        Assert.That(queue.Contains(3), Is.False, "Contains should return false.");
    }
    // Dequeue should throw an exception if the queue is empty.
    [Test]
    public void DequeueThrowsExceptionIfQueueIsEmpty()
    {
        var queue = new LQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }
    // Peek should throw an exception if the queue is empty.
    [Test]
    public void PeekThrowsExceptionIfQueueIsEmpty()
    {
        var queue = new LQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }
}