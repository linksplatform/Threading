using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Platform.Collections.Concurrent;

namespace Platform.Threading
{
    /// <summary>
    /// <para>Provides a set of extension methods for <see cref="ConcurrentQueue{T}"/> objects.</para>
    /// <para>Предоставляет набор методов расширения для объектов <see cref="ConcurrentQueue{T}"/>.</para>
    /// </summary>
    public static class ConcurrentQueueExtensions
    {
        /// <summary>
        /// <para>Suspends evaluation of the method until all asynchronous operations in the queue finish.</para>
        /// <para>Приостановляет выполнение метода до завершения всех асинхронных операций в очереди.</para>
        /// </summary>
        /// <param name="queue"><para>The queue of asynchronous operations.</para><para>Очередь асинхронных операций.</para></param>
        /// <returns><para>An asynchronous operation representation.</para><para>Представление асинхронной операции.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task AwaitAll(this ConcurrentQueue<Task> queue)
        {
            foreach (var item in queue.DequeueAll())
            {
                await item.ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// <para>Suspends evaluation of the method until the first asynchronous operation in the queue finishes.</para>
        /// <para>Приостанавливает выполнение метода до завершения первой асинхронной операции в очереди.</para>
        /// </summary>
        /// <param name="queue"><para>The queue of asynchronous operations.</para><para>Очередь асинхронных операций.</para></param>
        /// <returns><para>An asynchronous operation representation.</para><para>Представление асинхронной операции.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task AwaitOne(this ConcurrentQueue<Task> queue)
        {
            if (queue.TryDequeue(out Task item))
            {
                await item.ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// <para>Adds an <see cref="Action"/> as runned <see cref="Task"/> to the end of the <see cref="ConcurrentQueue{T}"/>.</para>
        /// <para>Добавляет <see cref="Action"/> как запущенную <see cref="Task"/> в конец <see cref="ConcurrentQueue{T}"/>.</para>
        /// </summary>
        /// <param name="queue"><para>The queue of asynchronous operations.</para><para>Очередь асинхронных операций.</para></param>
        /// <param name="action"><para>The <see cref="Action"/> delegate.</para><para>Делагат <see cref="Action"/>.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EnqueueAsRunnedTask(this ConcurrentQueue<Task> queue, Action action) => queue.Enqueue(Task.Run(action));
    }
}
