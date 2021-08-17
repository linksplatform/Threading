namespace Platform::Threading
{
    class TaskExtensions
    {
        public: template <typename TReturn> static TReturn AwaitResult(Task<TReturn> task) { return task.GetAwaiter().GetResult(); }
    };
}
