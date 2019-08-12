using System;

namespace Platform.Threading.Synchronization
{
    /// <summary>
    /// Implementation of <see cref="ISynchronization"/> that makes no actual synchronization.
    /// </summary>
    public class Unsynchronization : ISynchronization
    {
        /// <include file='bin\Release\netstandard2.0\Documentation.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation(System.Action)"]/*'/>
        public void ExecuteReadOperation(Action action) => action();

        /// <include file='bin\Release\netstandard2.0\Documentation.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation``1(System.Func{``0})"]/*'/>
        public TResult ExecuteReadOperation<TResult>(Func<TResult> function) => function();

        /// <include file='bin\Release\netstandard2.0\Documentation.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation(System.Action)"]/*'/>
        public void ExecuteWriteOperation(Action action) => action();

        /// <include file='bin\Release\netstandard2.0\Documentation.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation``1(System.Func{``0})"]/*'/>
        public TResult ExecuteWriteOperation<TResult>(Func<TResult> function) => function();
    }
}