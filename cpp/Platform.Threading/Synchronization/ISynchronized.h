#pragma once

#include "ISynchronization.h"
#include <memory>

namespace Platform::Threading::Synchronization
{
    /// <summary>
    /// <para>Represents extendable synchronized interface access gate.</para>
    /// <para>Представляет расширяемый интерфейс шлюза синхронизированного доступа.</para>
    /// </summary>
    /// <typeparam name="TInterface"><para>Synchronized interface.</para><para>Синхронизируемый интерфейс.</para></typeparam>
    template <typename TInterface>
    class ISynchronized
    {
    public:
        virtual ~ISynchronized() = default;

        /// <summary>
        /// <para>Gets synchronization method.</para>  
        /// <para>Возвращает способ синхронизации.</para>
        /// </summary>
        virtual std::shared_ptr<ISynchronization> GetSyncRoot() const = 0;

        /// <summary>
        /// <para>Get source version of TInterface, that does not guarantee thread safe access synchronization.</para>
        /// <para>Возвращает исходную версию TInterface, которая не гарантирует потокобезопасную синхронизацию доступа.</para>
        /// </summary>
        /// <remarks>
        /// <para>It is unsafe to use it directly, unless compound context using SyncRoot is created.</para>
        /// <para>Использовать напрямую небезопасно, за исключением ситуации когда создаётся составной контекст с использованием SyncRoot.</para>
        /// </remarks>
        virtual TInterface& GetUnsync() = 0;

        /// <summary>
        /// <para>Get wrapped/decorated version of TInterface, that does guarantee thread safe access synchronization.</para>
        /// <para>Возвращает обернутую/декорированную версию TInterface, которая гарантирует потокобезопасную синхронизацию доступа.</para>
        /// </summary>
        /// <remarks>
        /// <para>It is safe to use it directly, because it must be thread safe implementation.</para>
        /// <para>Безопасно использовать напрямую, так как реализация должна быть потокобезопасной.</para>
        /// </remarks>
        virtual TInterface& GetSync() = 0;

        /// <summary>
        /// <para>Get const source version of TInterface, that does not guarantee thread safe access synchronization.</para>
        /// <para>Возвращает константную исходную версию TInterface, которая не гарантирует потокобезопасную синхронизацию доступа.</para>
        /// </summary>
        virtual const TInterface& GetUnsync() const = 0;

        /// <summary>
        /// <para>Get const wrapped/decorated version of TInterface, that does guarantee thread safe access synchronization.</para>
        /// <para>Возвращает константную обернутую/декорированную версию TInterface, которая гарантирует потокобезопасную синхронизацию доступа.</para>
        /// </summary>
        virtual const TInterface& GetSync() const = 0;
    };
}
