using System;

namespace Platform.Threading.Synchronization
{
    /// <summary>
    /// <para>Implementation of <see cref="ISynchronization"/> that makes no actual synchronization.</para>
    /// <para>Реализация <see cref="ISynchronization"/>, которая не выполняет фактическую синхронизацию.</para>
    /// </summary>
    public class Unsynchronization : ISynchronization
    {
        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation(System.Action)"]/*'/>
        /// <inheritdoc/>
        public void ExecuteReadOperation(Action action) => action();

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation``1(System.Func{``0})"]/*'/>
        /// <inheritdoc/>
        public TResult ExecuteReadOperation<TResult>(Func<TResult> function) => function();

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation(System.Action)"]/*'/>
        /// <inheritdoc/>
        public void ExecuteWriteOperation(Action action) => action();

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation``1(System.Func{``0})"]/*'/>
        /// <inheritdoc/>
        public TResult ExecuteWriteOperation<TResult>(Func<TResult> function) => function();
    }
}