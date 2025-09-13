#pragma once

#include "ISynchronization.h"
#include <functional>

namespace Platform::Threading::Synchronization
{
    /// <summary>
    /// <para>Contains extension methods for the ISynchronization interface.</para>
    /// <para>Содержит методы расширения для интерфейса ISynchronization.</para>
    /// </summary>
    class ISynchronizationExtensions
    {
    public:
        // Single parameter overloads
        template<typename TResult, typename TParam>
        static TResult DoRead(ISynchronization& synchronization, TParam parameter, std::function<TResult(TParam)> function)
        {
            return synchronization.DoRead<TResult>([&]() { return function(parameter); });
        }

        template<typename TParam>
        static void DoRead(ISynchronization& synchronization, TParam parameter, std::function<void(TParam)> action)
        {
            synchronization.DoRead([&]() { action(parameter); });
        }

        template<typename TResult, typename TParam>
        static TResult DoWrite(ISynchronization& synchronization, TParam parameter, std::function<TResult(TParam)> function)
        {
            return synchronization.DoWrite<TResult>([&]() { return function(parameter); });
        }

        template<typename TParam>
        static void DoWrite(ISynchronization& synchronization, TParam parameter, std::function<void(TParam)> action)
        {
            synchronization.DoWrite([&]() { action(parameter); });
        }

        // Two parameter overloads
        template<typename TResult, typename TParam1, typename TParam2>
        static TResult DoRead(ISynchronization& synchronization, TParam1 parameter1, TParam2 parameter2, std::function<TResult(TParam1, TParam2)> function)
        {
            return synchronization.DoRead<TResult>([&]() { return function(parameter1, parameter2); });
        }

        template<typename TParam1, typename TParam2>
        static void DoRead(ISynchronization& synchronization, TParam1 parameter1, TParam2 parameter2, std::function<void(TParam1, TParam2)> action)
        {
            synchronization.DoRead([&]() { action(parameter1, parameter2); });
        }

        template<typename TResult, typename TParam1, typename TParam2>
        static TResult DoWrite(ISynchronization& synchronization, TParam1 parameter1, TParam2 parameter2, std::function<TResult(TParam1, TParam2)> function)
        {
            return synchronization.DoWrite<TResult>([&]() { return function(parameter1, parameter2); });
        }

        template<typename TParam1, typename TParam2>
        static void DoWrite(ISynchronization& synchronization, TParam1 parameter1, TParam2 parameter2, std::function<void(TParam1, TParam2)> action)
        {
            synchronization.DoWrite([&]() { action(parameter1, parameter2); });
        }

        // Three parameter overloads
        template<typename TResult, typename TParam1, typename TParam2, typename TParam3>
        static TResult DoRead(ISynchronization& synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, std::function<TResult(TParam1, TParam2, TParam3)> function)
        {
            return synchronization.DoRead<TResult>([&]() { return function(parameter1, parameter2, parameter3); });
        }

        template<typename TParam1, typename TParam2, typename TParam3>
        static void DoRead(ISynchronization& synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, std::function<void(TParam1, TParam2, TParam3)> action)
        {
            synchronization.DoRead([&]() { action(parameter1, parameter2, parameter3); });
        }

        template<typename TResult, typename TParam1, typename TParam2, typename TParam3>
        static TResult DoWrite(ISynchronization& synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, std::function<TResult(TParam1, TParam2, TParam3)> function)
        {
            return synchronization.DoWrite<TResult>([&]() { return function(parameter1, parameter2, parameter3); });
        }

        template<typename TParam1, typename TParam2, typename TParam3>
        static void DoWrite(ISynchronization& synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, std::function<void(TParam1, TParam2, TParam3)> action)
        {
            synchronization.DoWrite([&]() { action(parameter1, parameter2, parameter3); });
        }

        // Four parameter overloads
        template<typename TResult, typename TParam1, typename TParam2, typename TParam3, typename TParam4>
        static TResult DoRead(ISynchronization& synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, std::function<TResult(TParam1, TParam2, TParam3, TParam4)> function)
        {
            return synchronization.DoRead<TResult>([&]() { return function(parameter1, parameter2, parameter3, parameter4); });
        }

        template<typename TParam1, typename TParam2, typename TParam3, typename TParam4>
        static void DoRead(ISynchronization& synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, std::function<void(TParam1, TParam2, TParam3, TParam4)> action)
        {
            synchronization.DoRead([&]() { action(parameter1, parameter2, parameter3, parameter4); });
        }

        template<typename TResult, typename TParam1, typename TParam2, typename TParam3, typename TParam4>
        static TResult DoWrite(ISynchronization& synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, std::function<TResult(TParam1, TParam2, TParam3, TParam4)> function)
        {
            return synchronization.DoWrite<TResult>([&]() { return function(parameter1, parameter2, parameter3, parameter4); });
        }

        template<typename TParam1, typename TParam2, typename TParam3, typename TParam4>
        static void DoWrite(ISynchronization& synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, std::function<void(TParam1, TParam2, TParam3, TParam4)> action)
        {
            synchronization.DoWrite([&]() { action(parameter1, parameter2, parameter3, parameter4); });
        }
    };
}