using System;
using System.Threading;

namespace Platform.Threading.Synchronization
{
    public class ReaderWriterLockSynchronization : ISynchronization
    {
        private readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

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

        public T ExecuteReadOperation<T>(Func<T> func)
        {
            _rwLock.EnterReadLock();
            try
            {
                return func();
            }
            finally
            {
                _rwLock.ExitReadLock();
            }
        }

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

        public T ExecuteWriteOperation<T>(Func<T> func)
        {
            _rwLock.EnterWriteLock();
            try
            {
                return func();
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }
    }
}