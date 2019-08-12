using System;
using System.Threading;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Threading
{
    public static class ThreadHelpers
    {
        public static readonly int DefaultMaxStackSize;
        public static readonly int ExtendedMaxStackSize = 200 * 1024 * 1024;
        public static readonly int DefaultSleepTimeout = 1;

        public static void SyncInvokeWithExtendedStack<T>(T param, Action<object> action) => SyncInvokeWithExtendedStack(param, action, ExtendedMaxStackSize);

        public static void SyncInvokeWithExtendedStack<T>(T param, Action<object> action, int maxStackSize) => StartNew(param, action, maxStackSize).Join();

        public static void SyncInvokeWithExtendedStack(Action action) => SyncInvokeWithExtendedStack(action, ExtendedMaxStackSize);

        public static void SyncInvokeWithExtendedStack(Action action, int maxStackSize) => StartNew(action, maxStackSize).Join();

        public static Thread StartNew<T>(T param, Action<object> action) => StartNew(param, action, DefaultMaxStackSize);

        public static Thread StartNew<T>(T param, Action<object> action, int maxStackSize)
        {
            var thread = new Thread(new ParameterizedThreadStart(action), maxStackSize);
            thread.Start(param);
            return thread;
        }

        public static Thread StartNew(Action action) => StartNew(action, DefaultMaxStackSize);

        public static Thread StartNew(Action action, int maxStackSize)
        {
            var thread = new Thread(new ThreadStart(action), maxStackSize);
            thread.Start();
            return thread;
        }

        public static void Sleep() => Thread.Sleep(DefaultSleepTimeout);
    }
}
