namespace Platform::Threading::Synchronization
{
    class ISynchronization
    {
    public:
        virtual void ExecuteReadOperation(std::function<void()> action) = 0;

        TResult ExecuteReadOperation<TResult>(std::function<TResult()> function);

        virtual void ExecuteWriteOperation(std::function<void()> action) = 0;

        TResult ExecuteWriteOperation<TResult>(std::function<TResult()> function);
    };
}