#ifndef PLATFORM_THREADING
#define PLATFORM_THREADING

#include <map> // TODO: in Collections

#include <Platform.Collections.h>


#include <queue>
#include <future>
#include <thread>
#include <shared_mutex>

namespace Platform::Threading::Synchronization
{
    #include "Synchronization/sync/Sync.h"
}

#include "Synchronization/ReaderWriterLockSynchronization.h"
#include "ConcurrentQueueExtensions.h"


#endif
