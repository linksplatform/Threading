template<typename T,
    typename mutex_t = std::recursive_mutex,
    typename mut_lock_t = std::unique_lock<mutex_t>,
    typename lock_t = std::unique_lock<mutex_t>>
class Sync
{
    mutable T data;
    mutable mutex_t mutex;

    template<typename borrow_lock>
    struct locked_caller
    {
        borrow_lock lock;
        T* const ptr;

    public:
        locked_caller(T* const ptr, mutex_t& mutex) : ptr(ptr), lock(mutex) {}

        T* operator->() && { return ptr; }
        const T* operator->() const && { return ptr; }
    };

public:
    Sync() = default;

    Sync(auto&&... args) requires requires { decltype(data)(std::forward<decltype(args)>(args)...); }
        : data(std::forward<decltype(args)>(args)...),
          mutex() {}

    Sync(const Sync<T>& other)
        : data(other.data),
          mutex() {}

    Sync(Sync&&) noexcept = default;

    auto operator->()       { return locked_caller<mut_lock_t>(&data, mutex); }
    auto operator->() const { return locked_caller<lock_t>(&data, mutex); }

    /// friends
    template<typename... Args>
    friend auto&& Drop(Sync<Args...>&& self);
};

template<typename T>
Sync(T) -> Sync<T>;

template<typename... Args>
auto&& Drop(Sync<Args...>&& self) {
    return std::move(self.data);
}
