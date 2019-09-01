using System.Threading.Tasks;

namespace Platform.Threading
{
    /// <summary>
    /// <para>Provides a set of extension methods for <see cref="Task{TReturn}"/> objects.</para>
    /// <para>Предоставляет набор методов расширения для объектов <see cref="Task{TReturn}"/>.</para>
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// <para>Waits for completion of the asynchronous <see cref="Task{TReturn}"/> and returns its result.</para>
        /// <para>Ожидает завершения асинхронной <see cref="Task{TReturn}"/> и возвращает её результат.</para>
        /// </summary>
        /// <typeparam name="TReturn"><para>The return value type.</para><para>Тип возвращаемого значения.</para></typeparam>
        /// <param name="task"><para>The asynchronous <see cref="Task{TReturn}"/>.</para><para>Ассинхронная <see cref="Task{TReturn}"/>.</para></param>
        /// <returns><para>The result of completed <see cref="Task{TReturn}"/>.</para><para>Результат завершённой <see cref="Task{TReturn}"/>.</para></returns>
        public static TReturn AwaitResult<TReturn>(this Task<TReturn> task) => task.GetAwaiter().GetResult();
    }
}
