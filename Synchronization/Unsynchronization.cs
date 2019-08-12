using System;

namespace Platform.Threading.Synchronization
{
    /// <summary>
    /// <para>Implementation of <see cref="ISynchronization"/> that makes no actual synchronization.</para>
    /// <para>Реализация <see cref="ISynchronization"/>, которая не выполняет фактическую синхронизацию.</para>
    /// </summary>
    public class Unsynchronization : ISynchronization
    {
        /// <inheritdoc />
        public void ExecuteReadOperation(Action action) => action();

        /// <inheritdoc />
        public TResult ExecuteReadOperation<TResult>(Func<TResult> function) => function();

        /// <inheritdoc />
        public void ExecuteWriteOperation(Action action) => action();

        /// <inheritdoc />
        public TResult ExecuteWriteOperation<TResult>(Func<TResult> function) => function();
    }
}