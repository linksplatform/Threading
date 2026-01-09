namespace Platform::Threading::Synchronization
{
    template<
        typename mutex_t = std::recursive_mutex,
        template<typename> typename lock_t = std::unique_lock>
    void ExecuteReadOperation(auto&& action, auto&&... args)
    {
        static mutex_t mutex;

        lock_t lock(mutex);
        try
        {
            action(std::forward<decltype(args)>(args)...);
        } catch(...) {}
    }

    template<
        typename mutex_t = std::recursive_mutex,
        template<typename> typename lock_t = std::unique_lock>
    void ExecuteWriteOperation(auto&& action, auto&&... args)
    {
        static mutex_t mutex;

        lock_t lock(mutex);
        try
        {
            action(std::forward<decltype(args)>(args)...);
        } catch(...) {}
    }
}