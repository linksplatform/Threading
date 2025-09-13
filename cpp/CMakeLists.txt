cmake_minimum_required(VERSION 3.15)

project(Platform.Threading
    VERSION 1.0.0
    DESCRIPTION "C++ translation of Platform.Threading library"
    LANGUAGES CXX
)

# Set C++20 standard (required for std::jthread)
set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

# Compiler-specific options
if(MSVC)
    add_compile_options(/W4 /permissive-)
    # Enable std::jthread on MSVC
    add_definitions(-D_WIN32_WINNT=0x0A00)
else()
    add_compile_options(-Wall -Wextra -Wpedantic)
endif()

# Platform.Threading library
set(PLATFORM_THREADING_HEADERS
    Platform.Threading/ThreadHelpers.h
    Platform.Threading/TaskExtensions.h
    Platform.Threading/ConcurrentQueueExtensions.h
    Platform.Threading/Synchronization/ISynchronization.h
    Platform.Threading/Synchronization/ReaderWriterLockSynchronization.h
    Platform.Threading/Synchronization/Unsynchronization.h
    Platform.Threading/Synchronization/ISynchronized.h
    Platform.Threading/Synchronization/ISynchronizationExtensions.h
)

set(PLATFORM_THREADING_SOURCES
    Platform.Threading/ThreadHelpers.cpp
)

add_library(Platform.Threading ${PLATFORM_THREADING_SOURCES} ${PLATFORM_THREADING_HEADERS})

target_include_directories(Platform.Threading 
    PUBLIC 
        $<BUILD_INTERFACE:${CMAKE_CURRENT_SOURCE_DIR}>
        $<INSTALL_INTERFACE:include>
)

# Find required packages
find_package(Threads REQUIRED)

# Link threading library
target_link_libraries(Platform.Threading PUBLIC Threads::Threads)

# Set properties
set_target_properties(Platform.Threading PROPERTIES
    CXX_VISIBILITY_PRESET hidden
    VISIBILITY_INLINES_HIDDEN YES
    VERSION ${PROJECT_VERSION}
    SOVERSION 1
)

# Enable testing
enable_testing()

# Tests
if(BUILD_TESTING)
    add_subdirectory(Platform.Threading.Tests)
endif()

# Install targets
install(TARGETS Platform.Threading
    EXPORT Platform.ThreadingTargets
    LIBRARY DESTINATION lib
    ARCHIVE DESTINATION lib
    RUNTIME DESTINATION bin
    INCLUDES DESTINATION include
)

# Install headers
install(DIRECTORY Platform.Threading/
    DESTINATION include/Platform.Threading
    FILES_MATCHING PATTERN "*.h"
)

# Create package config files
include(CMakePackageConfigHelpers)
write_basic_package_version_file(
    "Platform.ThreadingConfigVersion.cmake"
    VERSION ${PROJECT_VERSION}
    COMPATIBILITY SameMajorVersion
)

install(EXPORT Platform.ThreadingTargets
    FILE Platform.ThreadingTargets.cmake
    NAMESPACE Platform::
    DESTINATION lib/cmake/Platform.Threading
)

configure_file(
    "${CMAKE_CURRENT_SOURCE_DIR}/cmake/Platform.ThreadingConfig.cmake.in"
    "${CMAKE_CURRENT_BINARY_DIR}/Platform.ThreadingConfig.cmake"
    @ONLY
)

install(FILES
    "${CMAKE_CURRENT_BINARY_DIR}/Platform.ThreadingConfig.cmake"
    "${CMAKE_CURRENT_BINARY_DIR}/Platform.ThreadingConfigVersion.cmake"
    DESTINATION lib/cmake/Platform.Threading
)