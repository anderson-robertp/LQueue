namespace LQueue;

using System;
using System.Diagnostics;

public static class CapacityExperiment
{
    /// <summary>
    ///  Measure the capacity of the queue as it grows.
    ///  The queue doubles in size every time it reaches capacity.
    ///
    /// Expected result:
    ///  List starts with small capacity.
    ///  As the queue grows, the capacity doubles.
    ///  This doubling growth gives a linear growth curve.
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("=== Capacity Experiment ===");
        
        // Create a queue with initial capacity of 10.
        var q = new LQueue<int>();
        
        // Measure the capacity of the queue as it grows.
        int previousCapacity = q.Capacity;
        Console.WriteLine($"Initial capacity: {previousCapacity}");
        
        // Enqueue 10,000 items.
        for (int i = 0; i < 10_000; i++)
        {
            // Enqueue an item and check the capacity.
            q.Enqueue(i);
            
            if (q.Capacity != previousCapacity)
            {
                Console.WriteLine($"Capacity increased from {previousCapacity} to {q.Capacity}");
                previousCapacity = q.Capacity;
            }
        }
        Console.WriteLine("Experiment complete.");
    }
    // Based on the experiment, the capacity of the queue doubles every time it reaches capacity.
    // The internal list doubles in size every time it reaches capacity.
    // This gives a linear growth curve. The capacity does not grow by 1 every time it reaches capacity.
    // The capacity doubles every time it reaches its limit size.
    // 
}


