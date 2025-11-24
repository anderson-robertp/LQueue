namespace LQueue;

using System;
using System.Collections.Generic;

public class LQueue<T>
{
    // Constructor
    private List<T> _list;

    // Initialize the list
    public LQueue()
    {
        _list = new List<T>();
    }
    
    // The Current number of elements in the queue
    public int Count => _list.Count;
    
    // The total number of elements in the queue
    public int Capacity => _list.Capacity;
    
    /// <summary>
    /// Adds an item to the back of the queue.
    /// Amortized O(1), but resizing may cause O(n) time.
    /// </summary>
    /// <param name="item"></param>
    public void Enqueue(T item) => _list.Add(item);

    /// <summary>
    /// Removes and returns the item at the front of the queue.
    /// Throws <see cref="InvalidOperationException"/> if the queue is empty.
    /// Expected time complexity: O(n) due to element shifting in the underlying list.
    /// </summary>
    /// <returns>The item at the front of the queue.</returns>
    public T Dequeue()
    {
        if (_list.Count == 0) throw new InvalidOperationException("Queue is empty.");
        T item = _list[0];
        _list.RemoveAt(0);
        return item;
    }
    
    /// <summary>
    /// Returns the value to the front of the queue without removing it.
    /// Throws <see cref="InvalidOperationException"/> if the queue is empty.
    /// Expected time complexity: O(1)
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public T Peek()
    {
        if (_list.Count == 0) throw new InvalidOperationException("Queue is empty.");
        return _list[0];
    }
    
    /// <summary>
    /// Returns true if the queue contains the specified item.
    /// Expected time complexity: O(n)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public bool Contains(T n) => _list.Contains(n);
}