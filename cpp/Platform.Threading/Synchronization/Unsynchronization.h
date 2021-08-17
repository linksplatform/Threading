namespace Platform::Threading::Synchronization
{
    class Unsynchronization : public ISynchronization
    {
        public: void ExecuteReadOperation(std::function<void()> action) { action(); }

        public: TResult ExecuteReadOperation<TResult>(std::function<TResult()> function) { return function(); }

        public: void ExecuteWriteOperation(std::function<void()> action) { action(); }

        public: TResult ExecuteWriteOperation<TResult>(std::function<TResult()> function) { return function(); }
    };
}