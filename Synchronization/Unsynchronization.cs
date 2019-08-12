using System;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Threading.Synchronization
{
    public class Unsynchronization : ISynchronization
    {
        public void ExecuteReadOperation(Action action) => action();
        public T ExecuteReadOperation<T>(Func<T> func) => func();
        public void ExecuteWriteOperation(Action action) => action();
        public T ExecuteWriteOperation<T>(Func<T> func) => func();
    }
}