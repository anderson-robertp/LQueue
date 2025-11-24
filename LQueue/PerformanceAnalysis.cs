namespace LQueue;

using System;
using System.Diagnostics;

/// <summary>
///  Performance Analysis Summary
///
/// ENQUEUE (Expected Big-O: O(1) amortized)
/// PEEK     (Expected Big-O: O(1))
/// CONTAINS (Expected Big-O: O(n) worst-case)
/// DEQUEUE  (Expected Big-O: O(n))
/// </summary>

public static class PerformanceAnalysis
{
    /// <summary>
    ///  Measure the performance of the queue operations; enqueue, peek, contains, and dequeue.
    /// Enqueue and peek are the most expensive operations.
    /// The average time for each operation is printed.
    /// 
    /// </summary>
    public static void Run()
    {
        int[] sizes = { 10, 100, 1_000, 10_000, 100_000 };

        foreach (int size in sizes)
        {
            Console.WriteLine();
            Console.WriteLine($"Running performance analysis for size {size}...");
            
            // Prefill queue
            var q = BuildQueue(size);

            MeasureEnqueue(size);
            MeasurePeek(size);
            MeasureContains(size);
            MeasureDequeue(size);
        }
    }

    /// <summary>
    ///  Create a queue with the specified size.
    /// </summary>
    /// <param name="size"></param>
    /// <returns>"q"</returns>
    private static LQueue<int> BuildQueue(int size)
    {
        // Create a queue with the specified size.
        var q = new LQueue<int>();
        // Enqueue items.
        for (int i = 0; i < size; i++)
        {
            q.Enqueue(i);
        }
        // return the queue.
        return q;
    }
    
    // ------------------------------------------------------------
    // PERFORMANCE MEASUREMENT METHODS
    //
    // Each one:
    //  - runs 10 trials
    //  - uses a queue of FIXED SIZE
    //  - measures a SINGLE operation per trial
    // ------------------------------------------------------------

    /// <summary>
    /// Expected Big-O: O(1) amortized.
    /// Measures a single enqueue when the queue has *size* elements.
    /// </summary>
    private static void MeasureEnqueue(int size)
    {
        long totalTicks = 0;
        int trials = 10;

        for (int i = 0; i < trials; i++)
        {
            var q = BuildQueue(size);
            Stopwatch sw = Stopwatch.StartNew();
            q.Enqueue(-1);
            sw.Stop();
            totalTicks += sw.ElapsedTicks;
        }
        
        Console.WriteLine($"Average enqueue time: {totalTicks / trials} ticks.");
    }
    
    /// <summary>
    /// Expected Big-O: O(1)
    /// Measures peek on a queue of fixed size.
    /// </summary>
    private static void MeasurePeek(int size)
    {
        long totalTicks = 0;
        int trials = 10;

        for (int i = 0; i < trials; i++)
        {
            var q = BuildQueue(size);
            Stopwatch sw = Stopwatch.StartNew();
            _ = q.Peek();
            sw.Stop();
            totalTicks += sw.ElapsedTicks;
        }

        Console.WriteLine($"Peek avg ticks: {totalTicks / trials}");
    }
    
    /// <summary>
    /// Expected Big-O: O(n)
    /// Measures contains using the *last element*, worst-case.
    /// </summary>
    private static void MeasureContains(int size)
    {
        long totalTicks = 0;
        int trials = 10;

        for (int i = 0; i < trials; i++)
        {
            var q = BuildQueue(size);
            Stopwatch sw = Stopwatch.StartNew();
            _ = q.Contains(size - 1);  // worst-case search
            sw.Stop();
            totalTicks += sw.ElapsedTicks;
        }

        Console.WriteLine($"Contains avg ticks: {totalTicks / trials}");
    }
    
    /// <summary>
    /// Expected Big-O: O(n) because List<T>.RemoveAt(0) shifts all elements.
    /// Measures one dequeue on a queue of *size*.
    /// </summary>
    private static void MeasureDequeue(int size)
    {
        long totalTicks = 0;
        int trials = 10;

        for (int i = 0; i < trials; i++)
        {
            var q = BuildQueue(size);
            Stopwatch sw = Stopwatch.StartNew();
            q.Dequeue();               // ONLY ONE dequeue
            sw.Stop();
            totalTicks += sw.ElapsedTicks;
        }

        Console.WriteLine($"Dequeue avg ticks: {totalTicks / trials}");
    }
}