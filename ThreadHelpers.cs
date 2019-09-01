using System;
using System.Threading;

namespace Platform.Threading
{
    /// <summary>
    /// <para>Provides a set of helper methods for <see cref="Thread"/> objects.</para>
    /// <para>Предоставляет набор вспомогательных методов для объектов <see cref="Thread"/>.</para>
    /// </summary>
    public static class ThreadHelpers
    {
        /// <summary>
        /// <para>Gets the maximum stack size in bytes by default.</para>
        /// <para>Возвращает размер максимальный стека в байтах по умолчанию.</para>
        /// </summary>
        public static readonly int DefaultMaxStackSize;

        /// <summary>
        /// <para>Gets the extended maximum stack size in bytes by default.</para>
        /// <para>Возвращает расширенный максимальный размер стека в байтах по умолчанию.</para>
        /// </summary>
        public static readonly int DefaultExtendedMaxStackSize = 200 * 1024 * 1024;

        /// <summary>
        /// <para>Returns the default time interval for transferring control to other threads in milliseconds</para>
        /// <para>Возвращает интервал времени для передачи управления другим потокам в миллисекундах по умолчанию.</para>
        /// </summary>
        public static readonly int DefaultSleepInterval = 1;

        /// <summary>
        /// <para>Invokes the <see cref="Action{T}"/> with modified maximum stack size.</para>
        /// <para>Вызывает <see cref="Action{T}"/> с изменённым максимальным размером стека.</para>
        /// </summary>
        /// <typeparam name="T"><para>The type of the <see cref="Action{T}"/> argument.</para><para>Тип аргумента <see cref="Action{T}"/>.</para></typeparam>
        /// <param name="param"><para>The object containing data to be used by the invoked <see cref="Action{T}"/> delegate.</para><para>Объект, содержащий данные, которые будут использоваться вызваемым делегатом <see cref="Action{T}"/>.</para></param>
        /// <param name="action"><para>The <see cref="Action{T}"/> delegate.</para><para>Делагат <see cref="Action{T}"/>.</para></param>
        /// <param name="maxStackSize"><para>The maximum stack size in bytes.</para><para>Максимальный размер стека в байтах.</para></param>
        public static void InvokeWithModifiedMaxStackSize<T>(T param, Action<object> action, int maxStackSize) => StartNew(param, action, maxStackSize).Join();

        /// <summary>
        /// <para>Invokes the <see cref="Action{T}"/> with extend maximum stack size.</para>
        /// <para>Вызывает <see cref="Action{T}"/> с расширенным максимальным размером стека.</para>
        /// </summary>
        /// <typeparam name="T"><para>The type of the <see cref="Action{T}"/> argument.</para><para>Тип аргумента <see cref="Action{T}"/>.</para></typeparam>
        /// <param name="param"><para>The object containing data to be used by the invoked <see cref="Action{T}"/> delegate.</para><para>Объект, содержащий данные, которые будут использоваться вызваемым делегатом <see cref="Action{T}"/>.</para></param>
        /// <param name="action"><para>The <see cref="Action{T}"/> delegate.</para><para>Делагат <see cref="Action{T}"/>.</para></param>
        public static void InvokeWithExtendedMaxStackSize<T>(T param, Action<object> action) => InvokeWithModifiedMaxStackSize(param, action, DefaultExtendedMaxStackSize);

        /// <summary>
        /// <para>Invokes the <see cref="Action"/> with modified maximum stack size.</para>
        /// <para>Вызывает <see cref="Action"/> с изменённым максимальным размером стека.</para>
        /// </summary>
        /// <param name="action"><para>The <see cref="Action"/> delegate.</para><para>Делагат <see cref="Action"/>.</para></param>
        /// <param name="maxStackSize"><para>The maximum stack size in bytes.</para><para>Максимальный размер стека в байтах.</para></param>
        public static void InvokeWithModifiedMaxStackSize(Action action, int maxStackSize) => StartNew(action, maxStackSize).Join();

        /// <summary>
        /// <para>Invokes the <see cref="Action"/> with extend maximum stack size.</para>
        /// <para>Вызывает <see cref="Action"/> с расширенным максимальным размером стека.</para>
        /// </summary>
        /// <param name="action"><para>The <see cref="Action"/> delegate.</para><para>Делагат <see cref="Action"/>.</para></param>
        public static void InvokeWithExtendedMaxStackSize(Action action) => InvokeWithModifiedMaxStackSize(action, DefaultExtendedMaxStackSize);

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Thread"/> class, causes the operating system to change the state of that instance to <see cref="ThreadState.Running"/> and supplies an object containing data to be used by the method that thread executes.</para>
        /// <para>Инициализирует новый экземпляр класса <see cref="Thread"/>, просит операционную систему изменить состояние этого экземпляра на <see cref="ThreadState.Running"/> и предоставляет объект, содержащий данные, которые будут использоваться в методе, который выполняет этот поток.</para>
        /// </summary>
        /// <typeparam name="T"><para>The type of the <see cref="Action{T}"/> argument.</para><para>Тип аргумента <see cref="Action{T}"/>.</para></typeparam>
        /// <param name="param"><para>The object containing data to be used by the method that thread executes.</para><para>Объект, содержащий данные, которые будут использоваться методом, выполняемым потоком.</para></param>
        /// <param name="action"><para>The <see cref="Action{T}"/> delegate.</para><para>Делагат <see cref="Action{T}"/>.</para></param>
        /// <param name="maxStackSize"><para>The maximum stack size in bytes.</para><para>Максимальный размер стека в байтах.</para></param>
        /// <returns><para>A new started <see cref="Thread"/> instance.</para><para>Новый запущенный экземпляр <see cref="Thread"/>.</para></returns>
        public static Thread StartNew<T>(T param, Action<object> action, int maxStackSize)
        {
            var thread = new Thread(new ParameterizedThreadStart(action), maxStackSize);
            thread.Start(param);
            return thread;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Thread"/> class, causes the operating system to change the state of that instance to <see cref="ThreadState.Running"/> and supplies an object containing data to be used by the method that thread executes.</para>
        /// <para>Инициализирует новый экземпляр класса <see cref="Thread"/>, просит операционную систему изменить состояние этого экземпляра на <see cref="ThreadState.Running"/> и предоставляет объект, содержащий данные, которые будут использоваться в методе, который выполняет этот поток.</para>
        /// </summary>
        /// <typeparam name="T"><para>The type of the <see cref="Action{T}"/> argument.</para><para>Тип аргумента <see cref="Action{T}"/>.</para></typeparam>
        /// <param name="param"><para>The object containing data to be used by the method that thread executes.</para><para>Объект, содержащий данные, которые будут использоваться методом, выполняемым потоком.</para></param>
        /// <param name="action"><para>The <see cref="Action{T}"/> delegate.</para><para>Делагат <see cref="Action{T}"/>.</para></param>
        /// <returns><para>A new started <see cref="Thread"/> instance.</para><para>Новый запущенный экземпляр <see cref="Thread"/>.</para></returns>
        public static Thread StartNew<T>(T param, Action<object> action) => StartNew(param, action, DefaultMaxStackSize);

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Thread"/> class, causes the operating system to change the state of that instance to <see cref="ThreadState.Running"/> and supplies the method executed by that thread.</para>
        /// <para>Инициализирует новый экземпляр класса <see cref="Thread"/>, просит операционную систему изменить состояние этого экземпляра на <see cref="ThreadState.Running"/> и предоставляет метод, который выполняется этим потоком.</para>
        /// </summary>
        /// <param name="action"><para>The <see cref="Action"/> delegate.</para><para>Делагат <see cref="Action"/>.</para></param>
        /// <param name="maxStackSize"><para>The maximum stack size in bytes.</para><para>Максимальный размер стека в байтах.</para></param>
        /// <returns><para>A new started <see cref="Thread"/> instance.</para><para>Новый запущенный экземпляр <see cref="Thread"/>.</para></returns>
        public static Thread StartNew(Action action, int maxStackSize)
        {
            var thread = new Thread(new ThreadStart(action), maxStackSize);
            thread.Start();
            return thread;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Thread"/> class, causes the operating system to change the state of that instance to <see cref="ThreadState.Running"/> and supplies the method executed by that thread.</para>
        /// <para>Инициализирует новый экземпляр класса <see cref="Thread"/>, просит операционную систему изменить состояние этого экземпляра на <see cref="ThreadState.Running"/> и предоставляет метод, который выполняется этим потоком.</para>
        /// </summary>
        /// <param name="action"><para>The <see cref="Action"/> delegate.</para><para>Делагат <see cref="Action"/>.</para></param>
        /// <returns><para>A new started <see cref="Thread"/> instance.</para><para>Новый запущенный экземпляр <see cref="Thread"/>.</para></returns>
        public static Thread StartNew(Action action) => StartNew(action, DefaultMaxStackSize);

        /// <summary>
        /// Suspends the current thread for the <see cref="DefaultSleepInterval"/>.
        /// </summary>
        public static void Sleep() => Thread.Sleep(DefaultSleepInterval);
    }
}
