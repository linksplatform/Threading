#pragma once

#include <future>
#include <functional>
#include <vector>
#include <queue>
#include <mutex>
#include <condition_variable>

namespace Platform::Threading
{
    /// <summary>
    /// Thread-safe queue implementation for concurrent operations
    /// </summary>
    template<typename T>
    class ConcurrentQueue
    {
    private:
        mutable std::mutex mutex_;
        std::queue<T> queue_;
        std::condition_variable condition_;

    public:
        /// <summary>
        /// Adds an item to the end of the queue
        /// </summary>
        void Enqueue(T item)
        {
            std::lock_guard<std::mutex> lock(mutex_);
            queue_.push(item);
            condition_.notify_one();
        }

        /// <summary>
        /// Attempts to remove and return the object at the beginning of the queue
        /// </summary>
        bool TryDequeue(T& result)
        {
            std::lock_guard<std::mutex> lock(mutex_);
            if (queue_.empty())
            {
                return false;
            }
            result = queue_.front();
            queue_.pop();
            return true;
        }

        /// <summary>
        /// Removes and returns all objects from the queue
        /// </summary>
        std::vector<T> DequeueAll()
        {
            std::lock_guard<std::mutex> lock(mutex_);
            std::vector<T> result;
            while (!queue_.empty())
            {
                result.push_back(queue_.front());
                queue_.pop();
            }
            return result;
        }

        /// <summary>
        /// Gets whether the queue is empty
        /// </summary>
        bool Empty() const
        {
            std::lock_guard<std::mutex> lock(mutex_);
            return queue_.empty();
        }

        /// <summary>
        /// Gets the number of elements in the queue
        /// </summary>
        size_t Size() const
        {
            std::lock_guard<std::mutex> lock(mutex_);
            return queue_.size();
        }
    };

    /// <summary>
    /// <para>Provides a set of extension methods for ConcurrentQueue objects with std::future.</para>
    /// <para>Предоставляет набор методов расширения для объектов ConcurrentQueue с std::future.</para>
    /// </summary>
    class ConcurrentQueueExtensions
    {
    public:
        /// <summary>
        /// <para>Waits for completion of all asynchronous operations in the queue.</para>
        /// <para>Ожидает завершения всех асинхронных операций в очереди.</para>
        /// </summary>
        /// <param name="queue"><para>The queue of asynchronous operations.</para><para>Очередь асинхронных операций.</para></param>
        template<typename T>
        static void AwaitAll(ConcurrentQueue<std::future<T>>& queue)
        {
            auto futures = queue.DequeueAll();
            for (auto& future : futures)
            {
                future.wait();
            }
        }

        /// <summary>
        /// <para>Waits for completion of all asynchronous operations in the queue (void specialization).</para>
        /// <para>Ожидает завершения всех асинхронных операций в очереди (специализация для void).</para>
        /// </summary>
        /// <param name="queue"><para>The queue of asynchronous operations.</para><para>Очередь асинхронных операций.</para></param>
        static void AwaitAll(ConcurrentQueue<std::future<void>>& queue)
        {
            auto futures = queue.DequeueAll();
            for (auto& future : futures)
            {
                future.wait();
            }
        }

        /// <summary>
        /// <para>Waits for completion of the first asynchronous operation in the queue.</para>
        /// <para>Ожидает завершения первой асинхронной операции в очереди.</para>
        /// </summary>
        /// <param name="queue"><para>The queue of asynchronous operations.</para><para>Очередь асинхронных операций.</para></param>
        template<typename T>
        static void AwaitOne(ConcurrentQueue<std::future<T>>& queue)
        {
            std::future<T> future;
            if (queue.TryDequeue(future))
            {
                future.wait();
            }
        }

        /// <summary>
        /// <para>Waits for completion of the first asynchronous operation in the queue (void specialization).</para>
        /// <para>Ожидает завершения первой асинхронной операции в очереди (специализация для void).</para>
        /// </summary>
        /// <param name="queue"><para>The queue of asynchronous operations.</para><para>Очередь асинхронных операций.</para></param>
        static void AwaitOne(ConcurrentQueue<std::future<void>>& queue)
        {
            std::future<void> future;
            if (queue.TryDequeue(future))
            {
                future.wait();
            }
        }

        /// <summary>
        /// <para>Adds a function as async task to the end of the queue.</para>
        /// <para>Добавляет функцию как асинхронную задачу в конец очереди.</para>
        /// </summary>
        /// <param name="queue"><para>The queue of asynchronous operations.</para><para>Очередь асинхронных операций.</para></param>
        /// <param name="action"><para>The function to run asynchronously.</para><para>Функция для асинхронного выполнения.</para></param>
        static void RunAndPush(ConcurrentQueue<std::future<void>>& queue, std::function<void()> action)
        {
            queue.Enqueue(std::async(std::launch::async, action));
        }

        /// <summary>
        /// <para>Adds a function as async task to the end of the queue.</para>
        /// <para>Добавляет функцию как асинхронную задачу в конец очереди.</para>
        /// </summary>
        /// <param name="queue"><para>The queue of asynchronous operations.</para><para>Очередь асинхронных операций.</para></param>
        /// <param name="function"><para>The function to run asynchronously.</para><para>Функция для асинхронного выполнения.</para></param>
        template<typename TReturn>
        static void RunAndPush(ConcurrentQueue<std::future<TReturn>>& queue, std::function<TReturn()> function)
        {
            queue.Enqueue(std::async(std::launch::async, function));
        }
    };
}
