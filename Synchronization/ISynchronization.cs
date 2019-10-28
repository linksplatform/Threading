using System;
using System.Runtime.CompilerServices;

namespace Platform.Threading.Synchronization
{
    /// <summary>
    /// <para>Represents a synchronization object that supports read and write operations.</para>
    /// <para>Представляет объект синхронизации с поддержкой операций чтения и записи.</para>
    /// </summary>
    public interface ISynchronization
    {
        /// <summary>
        /// <para>Executes action in read access mode.</para>
        /// <para>Выполняет действие в режиме доступа для чтения.</para>
        /// </summary>
        /// <param name="action"><para>The action.</para><para>Действие.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void ExecuteReadOperation(Action action);

        /// <summary>
        /// <para>Executes a function in read access mode and returns the function's result.</para>
        /// <para>Выполняет функцию в режиме доступа для чтения и возвращает полученный из неё результат.</para>
        /// </summary>
        /// <typeparam name="TResult"><para>Type of function's result.</para><para>Тип результата функции.</para></typeparam>
        /// <param name="function"><para>The function.</para><para>Функция.</para></param>
        /// <returns><para>The function's result.</para><para>Результат функции.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        TResult ExecuteReadOperation<TResult>(Func<TResult> function);

        /// <summary>
        /// <para>Executes action in write access mode.</para>
        /// <para>Выполняет действие в режиме доступа для записи.</para>
        /// </summary>
        /// <param name="action"><para>The action.</para><para>Действие.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void ExecuteWriteOperation(Action action);

        /// <summary>
        /// <para>Executes a function in write access mode and returns the function's result.</para>
        /// <para>Выполняет функцию в режиме доступа для записи и возвращает полученный из неё результат.</para>
        /// </summary>
        /// <typeparam name="TResult"><para>Type of function's result.</para><para>Тип результата функции.</para></typeparam>
        /// <param name="function"><para>The function.</para><para>Функция.</para></param>
        /// <returns><para>The function's result.</para><para>Результат функции.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        TResult ExecuteWriteOperation<TResult>(Func<TResult> function);
    }
}