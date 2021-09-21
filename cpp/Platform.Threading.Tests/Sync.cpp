namespace Platform::Threading::Tests
{
    TEST(Synchronization, Sync)
    {
        using namespace Synchronization;

        auto threads_count = 1000;
        auto map_operations_count = 100;
        Sync<std::map<std::string, int>> dict{};

        auto work = [&]
        {
            for (int i = 0; i < map_operations_count; i++)
            {
                dict->operator[](std::to_string(i))++;
            }
        };

        std::vector<std::thread> threads;

        for (int i = 0; i < threads_count; i++)
        {
            threads.push_back(std::thread(work));
        }

        for (auto& thread : threads) {
            thread.join();
        }

        for (auto&& [key, value] : Drop(std::move(dict))) {
            ASSERT_EQ(value, threads_count);
        }
    }

    TEST(Synchronization, Explicit)
    {
        using namespace Synchronization;

        auto threads_count = 1000;
        auto map_operations_count = 100;

        std::map<std::string, int> dict{};

        auto work = [&]
        {
            for (int i = 0; i < map_operations_count; i++)
            {
                dict.operator[](std::to_string(i))++;
            }
        };

        std::vector<std::thread> threads;

        for (int i = 0; i < threads_count; i++)
        {
            threads.push_back(std::thread([&] { ExecuteWriteOperation(work); }));
        }

        for (auto& thread : threads) {
            thread.join();
        }

        for (auto&& [key, value] : dict) {
            ASSERT_EQ(value, threads_count);
        }
    }
}