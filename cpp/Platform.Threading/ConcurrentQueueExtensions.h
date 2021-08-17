namespace Platform::Threading
{
    class ConcurrentQueueExtensions
    {
        public: static async Task AwaitAll(ConcurrentQueue<Task> queue)
        {
            foreach (auto item in queue.DequeueAll())
            {
                await item.ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        public: static async Task AwaitOne(ConcurrentQueue<Task> queue)
        {
            if (queue.TryDequeue(out Task item))
            {
                await item.ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        public: static void EnqueueAsRunnedTask(ConcurrentQueue<Task> queue, std::function<void()> action) { queue.Enqueue(Task.Run(action)); }
    };
}
