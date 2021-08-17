namespace Platform::Threading::Synchronization
{
    template <typename ...> class ISynchronized;
    template <typename TInterface> class ISynchronized<TInterface>
    {
    public:
        const ISynchronization *SyncRoot;

        const TInterface Unsync;

        const TInterface Sync;
    };
}
