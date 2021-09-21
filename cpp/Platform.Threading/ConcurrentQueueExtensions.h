namespace Platform::Threading
{
    template<typename R>
    auto AwaitAll(Synchronization::Sync<std::queue<std::future<R>>>& queue)
    {
        auto lambda = [&queue]
        {
            while (!queue->empty())
            {
                auto& item = queue->front();
                item.wait();
                queue->pop();
            }
        };
        return std::async(lambda);
    }

    template<typename R>
    auto AwaitOne(Synchronization::Sync<std::queue<std::future<R>>>& queue)
    {
        auto lambda = [&queue]
        {
            if (!queue->empty())
            {
                auto& item = queue->front();
                item.wait();
                queue->pop();
            }
        };
        return std::async(lambda);
    }

    // public: static void EnqueueAsRunnedTask(ConcurrentQueue<Task> queue, std::function<void()> action) { queue.Enqueue(Task.Run(action)); }
}
