#include <gtest/gtest.h>
#include <Platform.Threading/ThreadHelpers.h>
#include <atomic>

using namespace Platform::Threading;

class ThreadHelpersTests : public ::testing::Test 
{
protected:
    void SetUp() override {}
    void TearDown() override {}
};

TEST_F(ThreadHelpersTests, InvokeTest)
{
    std::atomic<int> number{0};
    
    // Test InvokeWithExtendedMaxStackSize with lambda
    ThreadHelpers::InvokeWithExtendedMaxStackSize([&number]() { 
        number = 1; 
    });
    EXPECT_EQ(1, number.load());
    
    // Test InvokeWithExtendedMaxStackSize with parameter
    ThreadHelpers::InvokeWithExtendedMaxStackSize(2, [&number](int param) { 
        number = param; 
    });
    EXPECT_EQ(2, number.load());
    
    // Test InvokeWithModifiedMaxStackSize with lambda
    ThreadHelpers::InvokeWithModifiedMaxStackSize([&number]() { 
        number = 3; 
    }, 512);
    EXPECT_EQ(3, number.load());
    
    // Test InvokeWithModifiedMaxStackSize with parameter
    ThreadHelpers::InvokeWithModifiedMaxStackSize(4, [&number](int param) { 
        number = param; 
    }, 512);
    EXPECT_EQ(4, number.load());
}

TEST_F(ThreadHelpersTests, StartNewTest)
{
    std::atomic<int> number{0};
    
    // Test StartNew with lambda
    auto thread1 = ThreadHelpers::StartNew([&number]() { 
        number = 10; 
    });
    thread1.join();
    EXPECT_EQ(10, number.load());
    
    // Test StartNew with parameter
    auto thread2 = ThreadHelpers::StartNew(20, [&number](int param) { 
        number = param; 
    });
    thread2.join();
    EXPECT_EQ(20, number.load());
}

TEST_F(ThreadHelpersTests, SleepTest)
{
    // Test that Sleep doesn't crash
    ThreadHelpers::Sleep();
    // Test passes if no exception is thrown
    SUCCEED();
}
