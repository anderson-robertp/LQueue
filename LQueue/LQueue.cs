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
    
    // Add an element to the queue
    public void Enqueue(T item) => _list.Add(item);
    
    //Remove and returns the value to the front of the queue
    public T Dequeue()
    {
        if (_list.Count == 0) throw new InvalidOperationException("Queue is empty.");
        T item = _list[0];
        _list.RemoveAt(0);
        return item;
    }
    
    //Returns the value to the front of the queue without removing it
    public T Peek()
    {
        if (_list.Count == 0) throw new InvalidOperationException("Queue is empty.");
        return _list[0];
    }
    
    //Returns true if the queue contains the value n
    public bool Contains(T n) => _list.Contains(n);
}