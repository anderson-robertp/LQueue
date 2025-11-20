namespace LQueue;

using System;
using System.Diagnostics;

public static class PerformanceAnalysis
{
    public static void Run()
    {
        int[] sizes = { 10, 100, 1_000, 10_000, 100_000 };

        foreach (int size in sizes)
        {
            Console.WriteLine();
            Console.WriteLine($"Running performance analysis for size {size}...");

            var q = new LQueue<int>();
            
            // Prefill queue

            for (int i = 0; i < size; i++)
            {
                q.Enqueue(i);
            }

            MeasureEnqueue(q);
            MeasurePeek(q);
            MeasureContains(q, size - 1);
            MeasureDequeue(q);
        }
    }
    
    // Measure enqueue performance
    private static void MeasureEnqueue(LQueue<int> q)
    {
        int trials = 10_000;
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < trials; i++)
        {
            q.Enqueue(-1);
        }
        
        stopwatch.Stop();
        Console.WriteLine($"Enqueue took {stopwatch.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Average enqueue time: {stopwatch.ElapsedMilliseconds / trials} ms.");
    }
    
    // Measure peek performance
    private static void MeasurePeek(LQueue<int> q)
    {
        int trials = 10_000;
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < trials; i++)
        {
            _ = q.Peek();
        }
        
        stopwatch.Stop();
        Console.WriteLine();
        Console.WriteLine($"Peek took {stopwatch.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Average peek time: {stopwatch.ElapsedMilliseconds / trials} ms.");
    }
    
    // Measure contains performance
    private static void MeasureContains(LQueue<int> q, int value)
    {
        int trials = 10_000;
        var stopwatch = new Stopwatch();

        for (int i = 0; i < trials; i++)
        {
            _ = q.Contains(value);
        }
        
        stopwatch.Stop();
        Console.WriteLine();
        Console.WriteLine($"Contains took {stopwatch.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Average contains time: {stopwatch.ElapsedMilliseconds / trials} ms.");
    }
    
    // Measure dequeue performance
    private static void MeasureDequeue(LQueue<int> q)
    {
        int trials = 10_000;
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < trials; i++)
        {
            q.Dequeue();
        }
        
        stopwatch.Stop();
        Console.WriteLine();
        Console.WriteLine($"Dequeue took {stopwatch.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Average dequeue time: {stopwatch.ElapsedMilliseconds / trials} ms.");
    }
}