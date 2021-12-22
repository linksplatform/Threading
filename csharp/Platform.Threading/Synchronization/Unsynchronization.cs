using System;
using System.Runtime.CompilerServices;

namespace Platform.Threading.Synchronization
{
    /// <summary>
    /// <para>Implementation of <see cref="ISynchronization"/> that makes no actual synchronization.</para>
    /// <para>Реализация <see cref="ISynchronization"/>, которая не выполняет фактическую синхронизацию.</para>
    /// </summary>
    public class Unsynchronization : ISynchronization
    {
        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.DoRead(System.Action)"]/*'/>
        /// <inheritdoc/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DoRead(Action action) => action();

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.DoRead``1(System.Func{``0})"]/*'/>
        /// <inheritdoc/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TResult DoRead<TResult>(Func<TResult> function) => function();

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.DoWrite(System.Action)"]/*'/>
        /// <inheritdoc/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DoWrite(Action action) => action();

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.DoWrite``1(System.Func{``0})"]/*'/>
        /// <inheritdoc/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TResult DoWrite<TResult>(Func<TResult> function) => function();
    }
}