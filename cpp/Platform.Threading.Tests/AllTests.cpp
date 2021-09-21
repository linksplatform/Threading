#include "Platform.Threading.h"

using namespace std::chrono_literals;
using namespace Platform::Threading;
using namespace Platform::Threading::Synchronization;


auto main() -> int {
    auto queue = std::queue<std::future<void>>();
    queue.push(std::async([]() { std::this_thread::sleep_for(50ms); std::cout << "I like C++\n"; }));
    queue.push(std::async([]() { std::cout << "C# it's Go\n"; }));
    queue.push(std::async([]() { std::this_thread::sleep_for(100ms); std::cout << "vno\n"; }));
    queue.push(std::async([]() { std::cout << "async programming is super\n"; }));

    auto sync_queue = sync(std::move(queue));
    AwaitOne(sync_queue).wait();
    auto queue_two = Drop(std::move(sync_queue));
    std::cout << "not waited count: " << queue_two.size() << std::endl;
}