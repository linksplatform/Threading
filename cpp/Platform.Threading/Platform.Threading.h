#ifndef PLATFORM_THREADING
#define PLATFORM_THREADING

#include <Platform.Collections.h>

#include <queue>
#include <future>
#include <thread>
#include <shared_mutex>

namespace Platform::Threading::Synchronization
{
    #include "Synchronization/sync/sync.h"
}

#include "ConcurrentQueueExtensions.h"


#endif
