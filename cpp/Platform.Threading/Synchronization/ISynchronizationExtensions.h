namespace Platform::Threading::Synchronization
{
    class ISynchronizationExtensions
    {
        public: static TResult ExecuteReadOperation<TResult, TParam>(ISynchronization &synchronization, TParam parameter, Func<TParam, TResult> function) { return synchronization.ExecuteReadOperation([&]()-> auto { return function(parameter); } });

        public: template <typename TParam> static void ExecuteReadOperation(ISynchronization &synchronization, TParam parameter, std::function<void(TParam)> action) { synchronization.ExecuteReadOperation([&]()-> auto { return action(parameter); }); }

        public: static TResult ExecuteWriteOperation<TResult, TParam>(ISynchronization &synchronization, TParam parameter, Func<TParam, TResult> function) { return synchronization.ExecuteWriteOperation([&]()-> auto { return function(parameter); } });

        public: template <typename TParam> static void ExecuteWriteOperation(ISynchronization &synchronization, TParam parameter, std::function<void(TParam)> action) { synchronization.ExecuteWriteOperation([&]()-> auto { return action(parameter); }); }

        public: static TResult ExecuteReadOperation<TResult, TParam1, TParam2>(ISynchronization &synchronization, TParam1 parameter1, TParam2 parameter2, Func<TParam1, TParam2, TResult> function) { return synchronization.ExecuteReadOperation([&]()-> auto { return function(parameter1, parameter2); } });

        public: static void ExecuteReadOperation<TParam1, TParam2>(ISynchronization &synchronization, TParam1 parameter1, TParam2 parameter2, std::function<void(TParam1, TParam2)> action) { return synchronization.ExecuteReadOperation([&]()-> auto { return action(parameter1, parameter2); } });

        public: static TResult ExecuteWriteOperation<TResult, TParam1, TParam2>(ISynchronization &synchronization, TParam1 parameter1, TParam2 parameter2, Func<TParam1, TParam2, TResult> function) { return synchronization.ExecuteWriteOperation([&]()-> auto { return function(parameter1, parameter2); } });

        public: static void ExecuteWriteOperation<TParam1, TParam2>(ISynchronization &synchronization, TParam1 parameter1, TParam2 parameter2, std::function<void(TParam1, TParam2)> action) { return synchronization.ExecuteWriteOperation([&]()-> auto { return action(parameter1, parameter2); } });

        public: static TResult ExecuteReadOperation<TResult, TParam1, TParam2, TParam3>(ISynchronization &synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, Func<TParam1, TParam2, TParam3, TResult> function) { return synchronization.ExecuteReadOperation([&]()-> auto { return function(parameter1, parameter2, parameter3); } });

        public: static void ExecuteReadOperation<TParam1, TParam2, TParam3>(ISynchronization &synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, std::function<void(TParam1, TParam2, TParam3)> action) { return synchronization.ExecuteReadOperation([&]()-> auto { return action(parameter1, parameter2, parameter3); } });

        public: static TResult ExecuteWriteOperation<TResult, TParam1, TParam2, TParam3>(ISynchronization &synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, Func<TParam1, TParam2, TParam3, TResult> function) { return synchronization.ExecuteWriteOperation([&]()-> auto { return function(parameter1, parameter2, parameter3); } });

        public: static void ExecuteWriteOperation<TParam1, TParam2, TParam3>(ISynchronization &synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, std::function<void(TParam1, TParam2, TParam3)> action) { return synchronization.ExecuteWriteOperation([&]()-> auto { return action(parameter1, parameter2, parameter3); } });

        public: static TResult ExecuteReadOperation<TResult, TParam1, TParam2, TParam3, TParam4>(ISynchronization &synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, Func<TParam1, TParam2, TParam3, TParam4, TResult> function) { return synchronization.ExecuteReadOperation([&]()-> auto { return function(parameter1, parameter2, parameter3, parameter4); } });

        public: static void ExecuteReadOperation<TParam1, TParam2, TParam3, TParam4>(ISynchronization &synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, std::function<void(TParam1, TParam2, TParam3, TParam4)> action) { return synchronization.ExecuteReadOperation([&]()-> auto { return action(parameter1, parameter2, parameter3, parameter4); } });

        public: static TResult ExecuteWriteOperation<TResult, TParam1, TParam2, TParam3, TParam4>(ISynchronization &synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, Func<TParam1, TParam2, TParam3, TParam4, TResult> function) { return synchronization.ExecuteWriteOperation([&]()-> auto { return function(parameter1, parameter2, parameter3, parameter4); } });

        public: static void ExecuteWriteOperation<TParam1, TParam2, TParam3, TParam4>(ISynchronization &synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, std::function<void(TParam1, TParam2, TParam3, TParam4)> action) { return synchronization.ExecuteWriteOperation([&]()-> auto { return action(parameter1, parameter2, parameter3, parameter4); } });
    };
}
