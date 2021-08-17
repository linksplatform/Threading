namespace Platform::Threading::Synchronization
{
    class ReaderWriterLockSynchronization : public ISynchronization
    {
        private: readonly ReaderWriterLockSlim _rwLock = ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        public: void ExecuteReadOperation(std::function<void()> action)
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

        public: TResult ExecuteReadOperation<TResult>(std::function<TResult()> function)
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

        public: void ExecuteWriteOperation(std::function<void()> action)
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

        public: TResult ExecuteWriteOperation<TResult>(std::function<TResult()> function)
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
    };
}