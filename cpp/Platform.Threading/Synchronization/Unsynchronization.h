#pragma once

#include "ISynchronization.h"
#include <functional>

namespace Platform::Threading::Synchronization
{
    /// <summary>
    /// <para>Implementation of ISynchronization that makes no actual synchronization.</para>
    /// <para>Реализация ISynchronization, которая не выполняет фактическую синхронизацию.</para>
    /// </summary>
    class Unsynchronization : public ISynchronization
    {
    public:
        /// <inheritdoc/>
        void DoRead(std::function<void()> action) override
        {
            action();
        }

        /// <summary>
        /// <para>Executes a function in read access mode and returns the function's result.</para>
        /// <para>Выполняет функцию в режиме доступа для чтения и возвращает полученный из неё результат.</para>
        /// </summary>
        /// <typeparam name="TResult"><para>Type of function's result.</para><para>Тип результата функции.</para></typeparam>
        /// <param name="function"><para>The function.</para><para>Функция.</para></param>
        /// <returns><para>The function's result.</para><para>Результат функции.</para></returns>
        template<typename TResult>
        TResult DoRead(std::function<TResult()> function)
        {
            return function();
        }

        /// <inheritdoc/>
        void DoWrite(std::function<void()> action) override
        {
            action();
        }

        /// <summary>
        /// <para>Executes a function in write access mode and returns the function's result.</para>
        /// <para>Выполняет функцию в режиме доступа для записи и возвращает полученный из неё результат.</para>
        /// </summary>
        /// <typeparam name="TResult"><para>Type of function's result.</para><para>Тип результата функции.</para></typeparam>
        /// <param name="function"><para>The function.</para><para>Функция.</para></param>
        /// <returns><para>The function's result.</para><para>Результат функции.</para></returns>
        template<typename TResult>
        TResult DoWrite(std::function<TResult()> function)
        {
            return function();
        }
    };
}