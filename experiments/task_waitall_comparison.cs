using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Linq;

namespace ExperimentComparison
{
    /// <summary>
    /// Experiment to compare ConcurrentQueueExtensions.AwaitAll vs Task.WaitAll approaches
    /// </summary>
    class TaskWaitAllComparison
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Comparing ConcurrentQueueExtensions.AwaitAll vs Task.WaitAll");
            
            // Create some sample tasks
            var queue = new ConcurrentQueue<Task>();
            queue.Enqueue(Task.Delay(100));
            queue.Enqueue(Task.Delay(200));
            queue.Enqueue(Task.Delay(150));
            
            // Current approach with ConcurrentQueueExtensions.AwaitAll
            Console.WriteLine("\n--- Current Approach (ConcurrentQueueExtensions.AwaitAll) ---");
            var start1 = DateTime.Now;
            
            // Simulate the AwaitAll behavior
            foreach (var item in queue.ToArray()) // DequeueAll equivalent
            {
                await item.ConfigureAwait(false);
            }
            
            var duration1 = DateTime.Now - start1;
            Console.WriteLine($"Sequential await duration: {duration1.TotalMilliseconds}ms");
            
            // Alternative approach with Task.WaitAll
            Console.WriteLine("\n--- Alternative Approach (Task.WaitAll) ---");
            var queue2 = new ConcurrentQueue<Task>();
            queue2.Enqueue(Task.Delay(100));
            queue2.Enqueue(Task.Delay(200));
            queue2.Enqueue(Task.Delay(150));
            
            var start2 = DateTime.Now;
            Task.WaitAll(queue2.ToArray());
            var duration2 = DateTime.Now - start2;
            Console.WriteLine($"Parallel wait duration: {duration2.TotalMilliseconds}ms");
            
            Console.WriteLine("\n--- Analysis ---");
            Console.WriteLine("Current AwaitAll approach: Awaits tasks sequentially (worse performance)");
            Console.WriteLine("Task.WaitAll approach: Waits for all tasks in parallel (better performance)");
            Console.WriteLine($"Performance difference: {duration1.TotalMilliseconds - duration2.TotalMilliseconds}ms");
        }
    }
}