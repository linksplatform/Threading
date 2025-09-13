# Platform.Threading.Tests

# Find or download Google Test
include(FetchContent)
FetchContent_Declare(
  googletest
  URL https://github.com/google/googletest/archive/03597a01ee50f33f9142fd2db5e2bc3d47f18e95.zip
)

# For Windows: Prevent overriding the parent project's compiler/linker settings
set(gtest_force_shared_crt ON CACHE BOOL "" FORCE)
FetchContent_MakeAvailable(googletest)

# Test sources
set(TEST_SOURCES
    ThreadHelpersTests.cpp
)

# Create test executable
add_executable(Platform.Threading.Tests ${TEST_SOURCES})

# Link libraries
target_link_libraries(Platform.Threading.Tests
    Platform.Threading
    gtest_main
    gmock_main
)

# Include directories
target_include_directories(Platform.Threading.Tests PRIVATE
    ${CMAKE_CURRENT_SOURCE_DIR}/../
)

# Discover tests
include(GoogleTest)
gtest_discover_tests(Platform.Threading.Tests)