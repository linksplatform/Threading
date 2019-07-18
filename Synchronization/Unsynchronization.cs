using System;

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