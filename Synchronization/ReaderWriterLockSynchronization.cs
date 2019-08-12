using System;
using System.Threading;

namespace Platform.Threading.Synchronization
{
    /// <summary>
    /// <para>Implementation of <see cref="ISynchronization"/> based on <see cref="ReaderWriterLockSlim"/>.</para>
    /// <para>Реализация <see cref="ISynchronization"/> на основе <see cref="ReaderWriterLockSlim"/>.</para>
    /// </summary>
    public class ReaderWriterLockSynchronization : ISynchronization
    {
        private readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation(System.Action)"]/*'/>
        /// <inheritdoc/>
        public void ExecuteReadOperation(Action action)
        {
            _rwLock.EnterReadLock();
            try
            {
                action();
            }
            finally
            {
                _rwLock.ExitReadLock();
            }
        }

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation``1(System.Func{``0})"]/*'/>
        /// <inheritdoc/>
        public TResult ExecuteReadOperation<TResult>(Func<TResult> function)
        {
            _rwLock.EnterReadLock();
            try
            {
                return function();
            }
            finally
            {
                _rwLock.ExitReadLock();
            }
        }

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation(System.Action)"]/*'/>
        /// <inheritdoc/>
        public void ExecuteWriteOperation(Action action)
        {
            _rwLock.EnterWriteLock();
            try
            {
                action();
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation``1(System.Func{``0})"]/*'/>
        /// <inheritdoc/>
        public TResult ExecuteWriteOperation<TResult>(Func<TResult> function)
        {
            _rwLock.EnterWriteLock();
            try
            {
                return function();
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }
    }
}