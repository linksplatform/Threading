namespace Platform::Threading
{
    template<typename R>
    auto AwaitAll(Synchronization::Sync<std::queue<std::future<R>>>& unsafe_queue)
    {
        auto lambda = [&unsafe_queue]
        {
            auto locked_queue = *unsafe_queue;
            auto& queue = *locked_queue;
            while (!queue.empty())
            {
                auto& item = queue.front();
                item.wait();
                queue.pop();
            }
        };
        return std::async(lambda);
    }

    template<typename R>
    auto AwaitOne(Synchronization::Sync<std::queue<std::future<R>>>& unsafe_queue)
    {
        auto lambda = [&unsafe_queue]
        {
            auto locked_queue = *unsafe_queue;
            auto& queue = *locked_queue;
            if (!queue.empty())
            {
                auto& item = queue.front();
                item.wait();
                queue.pop();
            }
        };
        return std::async(lambda);
    }

    // public: static void EnqueueAsRunnedTask(ConcurrentQueue<Task> queue, std::function<void()> action) { queue.Enqueue(Task.Run(action)); }
}
