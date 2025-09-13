#pragma once

#include <thread>
#include <functional>
#include <chrono>
#include <future>
#include <memory>

namespace Platform::Threading
{
    /// <summary>
    /// <para>Provides a set of helper methods for std::thread objects.</para>
    /// <para>Предоставляет набор вспомогательных методов для объектов std::thread.</para>
    /// </summary>
    class ThreadHelpers
    {
    public:
        /// <summary>
        /// <para>Gets the maximum stack size in bytes by default.</para>
        /// <para>Возвращает размер максимальный стека в байтах по умолчанию.</para>
        /// </summary>
        static std::int32_t DefaultMaxStackSize;

        /// <summary>
        /// <para>Gets the extended maximum stack size in bytes by default.</para>
        /// <para>Возвращает расширенный максимальный размер стека в байтах по умолчанию.</para>
        /// </summary>
        inline static const std::int32_t DefaultExtendedMaxStackSize = 256 * 1024 * 1024;

        /// <summary>
        /// <para>Returns the default time interval for transferring control to other threads in milliseconds</para>
        /// <para>Возвращает интервал времени для передачи управления другим потокам в миллисекундах по умолчанию.</para>
        /// </summary>
        inline static const std::int32_t DefaultSleepInterval = 1;

        /// <summary>
        /// <para>Invokes the function with modified maximum stack size.</para>
        /// <para>Вызывает функцию с изменённым максимальным размером стека.</para>
        /// </summary>
        /// <typeparam name="T"><para>The type of the parameter.</para><para>Тип параметра.</para></typeparam>
        /// <param name="param"><para>The object containing data to be used by the invoked function.</para><para>Объект, содержащий данные, которые будут использоваться вызываемой функцией.</para></param>
        /// <param name="action"><para>The function delegate.</para><para>Делагат функции.</para></param>
        /// <param name="maxStackSize"><para>The maximum stack size in bytes (Note: C++ std::thread doesn't support stack size without boost).</para><para>Максимальный размер стека в байтах (Примечание: std::thread C++ не поддерживает размер стека без boost).</para></param>
        template <typename T>
        static inline void InvokeWithModifiedMaxStackSize(T param, std::function<void(T)> action, std::int32_t maxStackSize)
        {
            auto thread = StartNew(param, action, maxStackSize);
            thread.join();
        }

        /// <summary>
        /// <para>Invokes the function with extend maximum stack size.</para>
        /// <para>Вызывает функцию с расширенным максимальным размером стека.</para>
        /// </summary>
        /// <typeparam name="T"><para>The type of the parameter.</para><para>Тип параметра.</para></typeparam>
        /// <param name="param"><para>The object containing data to be used by the invoked function.</para><para>Объект, содержащий данные, которые будут использоваться вызываемой функцией.</para></param>
        /// <param name="action"><para>The function delegate.</para><para>Делагат функции.</para></param>
        template <typename T>
        static inline void InvokeWithExtendedMaxStackSize(T param, std::function<void(T)> action)
        {
            InvokeWithModifiedMaxStackSize(param, action, DefaultExtendedMaxStackSize);
        }

        /// <summary>
        /// <para>Invokes the function with modified maximum stack size.</para>
        /// <para>Вызывает функцию с изменённым максимальным размером стека.</para>
        /// </summary>
        /// <param name="action"><para>The function delegate.</para><para>Делагат функции.</para></param>
        /// <param name="maxStackSize"><para>The maximum stack size in bytes (Note: C++ std::thread doesn't support stack size without boost).</para><para>Максимальный размер стека в байтах (Примечание: std::thread C++ не поддерживает размер стека без boost).</para></param>
        static inline void InvokeWithModifiedMaxStackSize(std::function<void()> action, std::int32_t maxStackSize)
        {
            auto thread = StartNew(action, maxStackSize);
            thread.join();
        }

        /// <summary>
        /// <para>Invokes the function with extend maximum stack size.</para>
        /// <para>Вызывает функцию с расширенным максимальным размером стека.</para>
        /// </summary>
        /// <param name="action"><para>The function delegate.</para><para>Делагат функции.</para></param>
        static inline void InvokeWithExtendedMaxStackSize(std::function<void()> action)
        {
            InvokeWithModifiedMaxStackSize(action, DefaultExtendedMaxStackSize);
        }

        /// <summary>
        /// <para>Initializes a new instance of the std::jthread class, causes the operating system to start that thread and supplies an object containing data to be used by the method that thread executes.</para>
        /// <para>Инициализирует новый экземпляр класса std::jthread, просит операционную систему запустить этот поток и предоставляет объект, содержащий данные, которые будут использоваться в методе, который выполняет этот поток.</para>
        /// </summary>
        /// <typeparam name="T"><para>The type of the parameter.</para><para>Тип параметра.</para></typeparam>
        /// <param name="param"><para>The object containing data to be used by the method that thread executes.</para><para>Объект, содержащий данные, которые будут использоваться методом, выполняемым потоком.</para></param>
        /// <param name="action"><para>The function delegate.</para><para>Делагат функции.</para></param>
        /// <param name="maxStackSize"><para>The maximum stack size in bytes (Note: ignored as std::jthread doesn't support stack size without boost).</para><para>Максимальный размер стека в байтах (Примечание: игнорируется, поскольку std::jthread не поддерживает размер стека без boost).</para></param>
        /// <returns><para>A new started std::jthread instance.</para><para>Новый запущенный экземпляр std::jthread.</para></returns>
        template <typename T>
        static inline std::jthread StartNew(T param, std::function<void(T)> action, std::int32_t maxStackSize)
        {
            return std::jthread([param, action]() {
                action(param);
            });
        }

        /// <summary>
        /// <para>Initializes a new instance of the std::jthread class, causes the operating system to start that thread and supplies an object containing data to be used by the method that thread executes.</para>
        /// <para>Инициализирует новый экземпляр класса std::jthread, просит операционную систему запустить этот поток и предоставляет объект, содержащий данные, которые будут использоваться в методе, который выполняет этот поток.</para>
        /// </summary>
        /// <typeparam name="T"><para>The type of the parameter.</para><para>Тип параметра.</para></typeparam>
        /// <param name="param"><para>The object containing data to be used by the method that thread executes.</para><para>Объект, содержащий данные, которые будут использоваться методом, выполняемым потоком.</para></param>
        /// <param name="action"><para>The function delegate.</para><para>Делагат функции.</para></param>
        /// <returns><para>A new started std::jthread instance.</para><para>Новый запущенный экземпляр std::jthread.</para></returns>
        template <typename T>
        static inline std::jthread StartNew(T param, std::function<void(T)> action)
        {
            return StartNew(param, action, DefaultMaxStackSize);
        }

        /// <summary>
        /// <para>Initializes a new instance of the std::jthread class, causes the operating system to start that thread and supplies the method executed by that thread.</para>
        /// <para>Инициализирует новый экземпляр класса std::jthread, просит операционную систему запустить этот поток и предоставляет метод, который выполняется этим потоком.</para>
        /// </summary>
        /// <param name="action"><para>The function delegate.</para><para>Делагат функции.</para></param>
        /// <param name="maxStackSize"><para>The maximum stack size in bytes (Note: ignored as std::jthread doesn't support stack size without boost).</para><para>Максимальный размер стека в байтах (Примечание: игнорируется, поскольку std::jthread не поддерживает размер стека без boost).</para></param>
        /// <returns><para>A new started std::jthread instance.</para><para>Новый запущенный экземпляр std::jthread.</para></returns>
        static inline std::jthread StartNew(std::function<void()> action, std::int32_t maxStackSize)
        {
            return std::jthread(action);
        }

        /// <summary>
        /// <para>Initializes a new instance of the std::jthread class, causes the operating system to start that thread and supplies the method executed by that thread.</para>
        /// <para>Инициализирует новый экземпляр класса std::jthread, просит операционную систему запустить этот поток и предоставляет метод, который выполняется этим потоком.</para>
        /// </summary>
        /// <param name="action"><para>The function delegate.</para><para>Делагат функции.</para></param>
        /// <returns><para>A new started std::jthread instance.</para><para>Новый запущенный экземпляр std::jthread.</para></returns>
        static inline std::jthread StartNew(std::function<void()> action)
        {
            return StartNew(action, DefaultMaxStackSize);
        }

        /// <summary>
        /// Suspends the current thread for the DefaultSleepInterval.
        /// </summary>
        static inline void Sleep()
        {
            std::this_thread::sleep_for(std::chrono::milliseconds(DefaultSleepInterval));
        }
    };
}
