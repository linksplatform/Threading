namespace Platform.Threading.Synchronization
{
    /// <summary>
    /// Represents extendable synchronized interface access gate.
    /// Представляет расширяемый интерфейс шлюза синхронизированного доступа.
    /// </summary>
    /// <typeparam name="TInterface">Synchronized interface. Синхронизируемый интерфейс.</typeparam>
    public interface ISynchronized<out TInterface>
    {
        /// <summary>
        /// Gets sychronization method.
        /// Возвращает способ синхронизации.
        /// </summary>
        ISynchronization SyncRoot { get; }

        /// <summary>
        /// Get source version of TInterface, that does not garantee thread safe access synchronization.
        /// Возвращает исходную версию TInterface, которая не гарантирует потокобезопасную синхронизацию доступа.
        /// </summary>
        /// <remarks>
        /// It is unsafe to use it directly, unless compound context using SyncRoot is created.
        /// Использовать напрямую небезопасно, за исключением ситуации когда создаётся составной контекст с использованием SyncRoot.
        /// </remarks>
        TInterface Unsync { get; }

        /// <summary>
        /// Get wrapped/decorated version of TInterface, that does garantee thread safe access synchronization.
        /// Возвращает обернутую/декорированную версию TInterface, которая гарантирует потокобезопасную синхронизацию доступа.
        /// </summary>
        /// <remarks>
        /// It is safe to use it directly, because it must be thread safe implementation.
        /// Безопасно использовать напрямую, так как реализация должна быть потокобезопасной.
        /// </remarks>
        TInterface Sync { get; }
    }
}
