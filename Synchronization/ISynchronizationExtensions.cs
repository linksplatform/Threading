using System;

namespace Platform.Threading.Synchronization
{
    /// <summary>
    /// <para>Contains extension methods for the <see cref="ISynchronization"/> interface.</para>
    /// <para>Содержит методы расширения для интерфейса <see cref="ISynchronization"/>.</para>
    /// </summary>
    public static class ISynchronizationExtensions
    {
        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation``1(System.Func{``0})"]/*'/>
        /// <typeparam name="TParam"><para>The parameter type.</para><para>Тип параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter"><para>The parameter</para><para>Параметр.</para></param>
        public static TResult ExecuteReadOperation<TResult, TParam>(this ISynchronization synchronization, TParam parameter, Func<TParam, TResult> function) => synchronization.ExecuteReadOperation(() => function(parameter));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation(System.Action)"]/*'/>
        /// <typeparam name="TParam"><para>The parameter type.</para><para>Тип параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter"><para>The parameter</para><para>Параметр.</para></param>
        public static void ExecuteReadOperation<TParam>(this ISynchronization synchronization, TParam parameter, Action<TParam> action) => synchronization.ExecuteReadOperation(() => action(parameter));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation``1(System.Func{``0})"]/*'/>
        /// <typeparam name="TParam"><para>The parameter type.</para><para>Тип параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter"><para>The parameter</para><para>Параметр.</para></param>
        public static TResult ExecuteWriteOperation<TResult, TParam>(this ISynchronization synchronization, TParam parameter, Func<TParam, TResult> function) => synchronization.ExecuteWriteOperation(() => function(parameter));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation(System.Action)"]/*'/>
        /// <typeparam name="TParam"><para>The parameter type.</para><para>Тип параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter"><para>The parameter</para><para>Параметр.</para></param>
        public static void ExecuteWriteOperation<TParam>(this ISynchronization synchronization, TParam parameter, Action<TParam> action) => synchronization.ExecuteWriteOperation(() => action(parameter));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation``1(System.Func{``0})"]/*'/>
        /// <typeparam name="TParam1"><para>The first parameter type.</para><para>Тип первого параметра.</para></typeparam>
        /// <typeparam name="TParam2"><para>The second parameter type.</para><para>Тип второго параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter1"><para>The first parameter</para><para>Первый параметр.</para></param>
        /// <param name="parameter2"><para>The second parameter</para><para>Второй параметр.</para></param>
        public static TResult ExecuteReadOperation<TResult, TParam1, TParam2>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, Func<TParam1, TParam2, TResult> function) => synchronization.ExecuteReadOperation(() => function(parameter1, parameter2));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation(System.Action)"]/*'/>
        /// <typeparam name="TParam1"><para>The first parameter type.</para><para>Тип первого параметра.</para></typeparam>
        /// <typeparam name="TParam2"><para>The second parameter type.</para><para>Тип второго параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter1"><para>The first parameter</para><para>Первый параметр.</para></param>
        /// <param name="parameter2"><para>The second parameter</para><para>Второй параметр.</para></param>
        public static void ExecuteReadOperation<TParam1, TParam2>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, Action<TParam1, TParam2> action) => synchronization.ExecuteReadOperation(() => action(parameter1, parameter2));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation``1(System.Func{``0})"]/*'/>
        /// <typeparam name="TParam1"><para>The first parameter type.</para><para>Тип первого параметра.</para></typeparam>
        /// <typeparam name="TParam2"><para>The second parameter type.</para><para>Тип второго параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter1"><para>The first parameter</para><para>Первый параметр.</para></param>
        /// <param name="parameter2"><para>The second parameter</para><para>Второй параметр.</para></param>
        public static TResult ExecuteWriteOperation<TResult, TParam1, TParam2>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, Func<TParam1, TParam2, TResult> function) => synchronization.ExecuteWriteOperation(() => function(parameter1, parameter2));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation(System.Action)"]/*'/>
        /// <typeparam name="TParam1"><para>The first parameter type.</para><para>Тип первого параметра.</para></typeparam>
        /// <typeparam name="TParam2"><para>The second parameter type.</para><para>Тип второго параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter1"><para>The first parameter</para><para>Первый параметр.</para></param>
        /// <param name="parameter2"><para>The second parameter</para><para>Второй параметр.</para></param>
        public static void ExecuteWriteOperation<TParam1, TParam2>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, Action<TParam1, TParam2> action) => synchronization.ExecuteWriteOperation(() => action(parameter1, parameter2));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation``1(System.Func{``0})"]/*'/>
        /// <typeparam name="TParam1"><para>The first parameter type.</para><para>Тип первого параметра.</para></typeparam>
        /// <typeparam name="TParam2"><para>The second parameter type.</para><para>Тип второго параметра.</para></typeparam>
        /// <typeparam name="TParam3"><para>The third parameter type.</para><para>Тип третьего параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter1"><para>The first parameter</para><para>Первый параметр.</para></param>
        /// <param name="parameter2"><para>The second parameter</para><para>Второй параметр.</para></param>
        /// <param name="parameter3"><para>The third parameter</para><para>Третий параметр.</para></param>
        public static TResult ExecuteReadOperation<TResult, TParam1, TParam2, TParam3>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, Func<TParam1, TParam2, TParam3, TResult> function) => synchronization.ExecuteReadOperation(() => function(parameter1, parameter2, parameter3));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation(System.Action)"]/*'/>
        /// <typeparam name="TParam1"><para>The first parameter type.</para><para>Тип первого параметра.</para></typeparam>
        /// <typeparam name="TParam2"><para>The second parameter type.</para><para>Тип второго параметра.</para></typeparam>
        /// <typeparam name="TParam3"><para>The third parameter type.</para><para>Тип третьего параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter1"><para>The first parameter</para><para>Первый параметр.</para></param>
        /// <param name="parameter2"><para>The second parameter</para><para>Второй параметр.</para></param>
        /// <param name="parameter3"><para>The third parameter</para><para>Третий параметр.</para></param>
        public static void ExecuteReadOperation<TParam1, TParam2, TParam3>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, Action<TParam1, TParam2, TParam3> action) => synchronization.ExecuteReadOperation(() => action(parameter1, parameter2, parameter3));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation``1(System.Func{``0})"]/*'/>
        /// <typeparam name="TParam1"><para>The first parameter type.</para><para>Тип первого параметра.</para></typeparam>
        /// <typeparam name="TParam2"><para>The second parameter type.</para><para>Тип второго параметра.</para></typeparam>
        /// <typeparam name="TParam3"><para>The third parameter type.</para><para>Тип третьего параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter1"><para>The first parameter</para><para>Первый параметр.</para></param>
        /// <param name="parameter2"><para>The second parameter</para><para>Второй параметр.</para></param>
        /// <param name="parameter3"><para>The third parameter</para><para>Третий параметр.</para></param>
        public static TResult ExecuteWriteOperation<TResult, TParam1, TParam2, TParam3>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, Func<TParam1, TParam2, TParam3, TResult> function) => synchronization.ExecuteWriteOperation(() => function(parameter1, parameter2, parameter3));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation(System.Action)"]/*'/>
        /// <typeparam name="TParam1"><para>The first parameter type.</para><para>Тип первого параметра.</para></typeparam>
        /// <typeparam name="TParam2"><para>The second parameter type.</para><para>Тип второго параметра.</para></typeparam>
        /// <typeparam name="TParam3"><para>The third parameter type.</para><para>Тип третьего параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter1"><para>The first parameter</para><para>Первый параметр.</para></param>
        /// <param name="parameter2"><para>The second parameter</para><para>Второй параметр.</para></param>
        /// <param name="parameter3"><para>The third parameter</para><para>Третий параметр.</para></param>
        public static void ExecuteWriteOperation<TParam1, TParam2, TParam3>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, Action<TParam1, TParam2, TParam3> action) => synchronization.ExecuteWriteOperation(() => action(parameter1, parameter2, parameter3));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation``1(System.Func{``0})"]/*'/>
        /// <typeparam name="TParam1"><para>The first parameter type.</para><para>Тип первого параметра.</para></typeparam>
        /// <typeparam name="TParam2"><para>The second parameter type.</para><para>Тип второго параметра.</para></typeparam>
        /// <typeparam name="TParam3"><para>The third parameter type.</para><para>Тип третьего параметра.</para></typeparam>
        /// <typeparam name="TParam4"><para>The forth parameter type.</para><para>Тип четвёртого параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter1"><para>The first parameter</para><para>Первый параметр.</para></param>
        /// <param name="parameter2"><para>The second parameter</para><para>Второй параметр.</para></param>
        /// <param name="parameter3"><para>The third parameter</para><para>Третий параметр.</para></param>
        /// <param name="parameter4"><para>The forth parameter</para><para>Чертвёртый параметр.</para></param>
        public static TResult ExecuteReadOperation<TResult, TParam1, TParam2, TParam3, TParam4>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, Func<TParam1, TParam2, TParam3, TParam4, TResult> function) => synchronization.ExecuteReadOperation(() => function(parameter1, parameter2, parameter3, parameter4));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteReadOperation(System.Action)"]/*'/>
        /// <typeparam name="TParam1"><para>The first parameter type.</para><para>Тип первого параметра.</para></typeparam>
        /// <typeparam name="TParam2"><para>The second parameter type.</para><para>Тип второго параметра.</para></typeparam>
        /// <typeparam name="TParam3"><para>The third parameter type.</para><para>Тип третьего параметра.</para></typeparam>
        /// <typeparam name="TParam4"><para>The forth parameter type.</para><para>Тип четвёртого параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter1"><para>The first parameter</para><para>Первый параметр.</para></param>
        /// <param name="parameter2"><para>The second parameter</para><para>Второй параметр.</para></param>
        /// <param name="parameter3"><para>The third parameter</para><para>Третий параметр.</para></param>
        /// <param name="parameter4"><para>The forth parameter</para><para>Чертвёртый параметр.</para></param>
        public static void ExecuteReadOperation<TParam1, TParam2, TParam3, TParam4>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, Action<TParam1, TParam2, TParam3, TParam4> action) => synchronization.ExecuteReadOperation(() => action(parameter1, parameter2, parameter3, parameter4));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation``1(System.Func{``0})"]/*'/>
        /// <typeparam name="TParam1"><para>The first parameter type.</para><para>Тип первого параметра.</para></typeparam>
        /// <typeparam name="TParam2"><para>The second parameter type.</para><para>Тип второго параметра.</para></typeparam>
        /// <typeparam name="TParam3"><para>The third parameter type.</para><para>Тип третьего параметра.</para></typeparam>
        /// <typeparam name="TParam4"><para>The forth parameter type.</para><para>Тип четвёртого параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter1"><para>The first parameter</para><para>Первый параметр.</para></param>
        /// <param name="parameter2"><para>The second parameter</para><para>Второй параметр.</para></param>
        /// <param name="parameter3"><para>The third parameter</para><para>Третий параметр.</para></param>
        /// <param name="parameter4"><para>The forth parameter</para><para>Чертвёртый параметр.</para></param>
        public static TResult ExecuteWriteOperation<TResult, TParam1, TParam2, TParam3, TParam4>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, Func<TParam1, TParam2, TParam3, TParam4, TResult> function) => synchronization.ExecuteWriteOperation(() => function(parameter1, parameter2, parameter3, parameter4));

        /// <include file='bin\Release\netstandard2.0\Platform.Threading.xml' path='doc/members/member[@name="M:Platform.Threading.Synchronization.ISynchronization.ExecuteWriteOperation(System.Action)"]/*'/>
        /// <typeparam name="TParam1"><para>The first parameter type.</para><para>Тип первого параметра.</para></typeparam>
        /// <typeparam name="TParam2"><para>The second parameter type.</para><para>Тип второго параметра.</para></typeparam>
        /// <typeparam name="TParam3"><para>The third parameter type.</para><para>Тип третьего параметра.</para></typeparam>
        /// <typeparam name="TParam4"><para>The forth parameter type.</para><para>Тип четвёртого параметра.</para></typeparam>
        /// <param name="synchronization"><para>Synchronization object.</para><para>Синхронизация объекта.</para></param>
        /// <param name="parameter1"><para>The first parameter</para><para>Первый параметр.</para></param>
        /// <param name="parameter2"><para>The second parameter</para><para>Второй параметр.</para></param>
        /// <param name="parameter3"><para>The third parameter</para><para>Третий параметр.</para></param>
        /// <param name="parameter4"><para>The forth parameter</para><para>Чертвёртый параметр.</para></param>
        public static void ExecuteWriteOperation<TParam1, TParam2, TParam3, TParam4>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, Action<TParam1, TParam2, TParam3, TParam4> action) => synchronization.ExecuteWriteOperation(() => action(parameter1, parameter2, parameter3, parameter4));
    }
}
