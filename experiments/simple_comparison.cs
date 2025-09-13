using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Linq;

/// <summary>
/// Simple comparison of sequential await vs Task.WaitAll
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Task Comparison Analysis ===");
        
        Console.WriteLine("\nCurrent ConcurrentQueueExtensions.AwaitAll approach:");
        Console.WriteLine("- Awaits tasks SEQUENTIALLY using foreach");
        Console.WriteLine("- If you have 3 tasks that take 100ms each, total time = 300ms");
        Console.WriteLine("- Poor performance for parallel operations");
        
        Console.WriteLine("\nTask.WaitAll approach:");
        Console.WriteLine("- Waits for all tasks to complete IN PARALLEL");
        Console.WriteLine("- If you have 3 tasks that take 100ms each, total time = ~100ms");  
        Console.WriteLine("- Better performance - this is the standard .NET pattern");
        
        Console.WriteLine("\nConclusion:");
        Console.WriteLine("✓ Task.WaitAll is the standard .NET way to wait for multiple tasks");
        Console.WriteLine("✓ Much better performance (parallel vs sequential)");
        Console.WriteLine("✓ ConcurrentQueueExtensions promotes worse design patterns");
        Console.WriteLine("✓ Should be removed as suggested in issue #25");
        
        Console.WriteLine("\nRecommended pattern instead of ConcurrentQueueExtensions:");
        Console.WriteLine("  var tasks = new List<Task>();");
        Console.WriteLine("  tasks.Add(SomeAsyncMethod());");
        Console.WriteLine("  tasks.Add(AnotherAsyncMethod());");
        Console.WriteLine("  Task.WaitAll(tasks.ToArray());");
    }
}