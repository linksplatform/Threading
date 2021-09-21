namespace Platform::Threading::Tests
{
    TEST(Await, One)
    {
        using namespace Synchronization;
        using namespace std::chrono_literals;

        auto queue = std::queue<std::future<void>>();
        queue.push(std::async([]() { std::this_thread::sleep_for(50ms); std::cout << "I like C++\n"; }));
        queue.push(std::async([]() { std::cout << "C# it's Go\n"; }));
        queue.push(std::async([]() { std::this_thread::sleep_for(100ms); std::cout << "lang\n"; }));
        queue.push(std::async([]() { std::cout << "async programming is super\n"; }));

        auto sync_queue = Sync(std::move(queue));
        AwaitOne(sync_queue).wait();
        auto queue_two = Drop(std::move(sync_queue));
        std::cout << "not waited count: " << queue_two.size() << std::endl;
    }
}