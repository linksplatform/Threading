using System.Runtime.CompilerServices;

namespace Platform.Threading.Synchronization
{
    /// <summary>
    /// <para>Represents extendable synchronized interface access gate.</para>
    /// <para>Представляет расширяемый интерфейс шлюза синхронизированного доступа.</para>
    /// </summary>
    /// <typeparam name="TInterface"><para>Synchronized interface.</para><para>Синхронизируемый интерфейс.</para></typeparam>
    public interface ISynchronized<out TInterface>
    {
        /// <summary>
        /// <para>Gets sychronization method.</para>  
        /// <para>Возвращает способ синхронизации.</para>
        /// </summary>
        ISynchronization SyncRoot
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        /// <summary>
        /// <para>Get source version of <typeparamref name="TInterface"/>, that does not garantee thread safe access synchronization.</para>
        /// <para>Возвращает исходную версию <typeparamref name="TInterface"/>, которая не гарантирует потокобезопасную синхронизацию доступа.</para>
        /// </summary>
        /// <remarks>
        /// <para>It is unsafe to use it directly, unless compound context using SyncRoot is created.</para>
        /// <para>Использовать напрямую небезопасно, за исключением ситуации когда создаётся составной контекст с использованием SyncRoot.</para>
        /// </remarks>
        TInterface Unsync
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        /// <summary>
        /// <para>Get wrapped/decorated version of <typeparamref name="TInterface"/>, that does garantee thread safe access synchronization.</para>
        /// <para>Возвращает обернутую/декорированную версию <typeparamref name="TInterface"/>, которая гарантирует потокобезопасную синхронизацию доступа.</para>
        /// </summary>
        /// <remarks>
        /// <para>It is safe to use it directly, because it must be thread safe implementation.</para>
        /// <para>Безопасно использовать напрямую, так как реализация должна быть потокобезопасной.</para>
        /// </remarks>
        TInterface Sync
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }
    }
}
