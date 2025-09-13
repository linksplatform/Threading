#pragma once

#include <future>
#include <type_traits>

namespace Platform::Threading
{
    /// <summary>
    /// <para>Provides a set of extension methods for std::future objects.</para>
    /// <para>Предоставляет набор методов расширения для объектов std::future.</para>
    /// </summary>
    class TaskExtensions
    {
    public:
        /// <summary>
        /// <para>Waits for completion of the asynchronous std::future and returns its result.</para>
        /// <para>Ожидает завершения асинхронного std::future и возвращает её результат.</para>
        /// </summary>
        /// <typeparam name="TReturn"><para>The return value type.</para><para>Тип возвращаемого значения.</para></typeparam>
        /// <param name="future"><para>The asynchronous std::future.</para><para>Асинхронный std::future.</para></param>
        /// <returns><para>The result of completed std::future.</para><para>Результат завершённого std::future.</para></returns>
        template <typename TReturn>
        static inline TReturn AwaitResult(std::future<TReturn>& future)
        {
            return future.get();
        }

        /// <summary>
        /// <para>Waits for completion of the asynchronous std::future and returns its result.</para>
        /// <para>Ожидает завершения асинхронного std::future и возвращает её результат.</para>
        /// </summary>
        /// <typeparam name="TReturn"><para>The return value type.</para><para>Тип возвращаемого значения.</para></typeparam>
        /// <param name="future"><para>The asynchronous std::future.</para><para>Асинхронный std::future.</para></param>
        /// <returns><para>The result of completed std::future.</para><para>Результат завершённого std::future.</para></returns>
        template <typename TReturn>
        static inline TReturn AwaitResult(std::future<TReturn>&& future)
        {
            return future.get();
        }

        /// <summary>
        /// <para>Waits for completion of the asynchronous std::shared_future and returns its result.</para>
        /// <para>Ожидает завершения асинхронного std::shared_future и возвращает её результат.</para>
        /// </summary>
        /// <typeparam name="TReturn"><para>The return value type.</para><para>Тип возвращаемого значения.</para></typeparam>
        /// <param name="future"><para>The asynchronous std::shared_future.</para><para>Асинхронный std::shared_future.</para></param>
        /// <returns><para>The result of completed std::shared_future.</para><para>Результат завершённого std::shared_future.</para></returns>
        template <typename TReturn>
        static inline TReturn AwaitResult(std::shared_future<TReturn>& future)
        {
            return future.get();
        }
    };
}
