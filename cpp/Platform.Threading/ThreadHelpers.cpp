#include "ThreadHelpers.h"

namespace Platform::Threading
{
    // Initialize static member - use default thread stack size
    std::int32_t ThreadHelpers::DefaultMaxStackSize = 0; // 0 means use system default
}