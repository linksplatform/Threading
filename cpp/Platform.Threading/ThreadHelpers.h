namespace Platform::Threading
{
    class ThreadHelpers
    {
        public: static std::int32_t DefaultMaxStackSize;

        public: inline static const std::int32_t DefaultExtendedMaxStackSize = 256 * 1024 * 1024;

        public: inline static const std::int32_t DefaultSleepInterval = 1;

        public: template <typename T> static void InvokeWithModifiedMaxStackSize(T param, std::function<void(void*)> action, std::int32_t maxStackSize) { StartNew(param, action, maxStackSize).Join(); }

        public: template <typename T> static void InvokeWithExtendedMaxStackSize(T param, std::function<void(void*)> action) { InvokeWithModifiedMaxStackSize(param, action, DefaultExtendedMaxStackSize); }

        public: static void InvokeWithModifiedMaxStackSize(std::function<void()> action, std::int32_t maxStackSize) { StartNew(action, maxStackSize).Join(); }

        public: static void InvokeWithExtendedMaxStackSize(std::function<void()> action) { InvokeWithModifiedMaxStackSize(action, DefaultExtendedMaxStackSize); }

        public: template <typename T> static Thread StartNew(T param, std::function<void(void*)> action, std::int32_t maxStackSize)
        {
            auto thread = Thread(ParameterizedThreadStart(action), maxStackSize);
            thread.Start(param);
            return thread;
        }

        public: template <typename T> static Thread StartNew(T param, std::function<void(void*)> action) { return StartNew(param, action, DefaultMaxStackSize); }

        public: static Thread StartNew(std::function<void()> action, std::int32_t maxStackSize)
        {
            auto thread = Thread(ThreadStart(action), maxStackSize);
            thread.Start();
            return thread;
        }

        public: static Thread StartNew(std::function<void()> action) { return StartNew(action, DefaultMaxStackSize); }

        public: static void Sleep() { Thread.Sleep(DefaultSleepInterval); }
    };
}
