template<typename T,
    typename mutex_t = std::recursive_mutex,
    typename mut_lock_t = std::unique_lock<mutex_t>,
    typename lock_t = std::unique_lock<mutex_t>>
class sync
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
    sync() = default;

    sync(auto&&... args) requires requires { decltype(data)(std::forward<decltype(args)>(args)...); }
        : data(std::forward<decltype(args)>(args)...),
          mutex() {}

    sync(const sync<T>& other)
        : data(other.data),
          mutex() {}

    sync(sync&&) noexcept = default;

    auto operator->()       { return locked_caller<mut_lock_t>(&data, mutex); }
    auto operator->() const { return locked_caller<lock_t>(&data, mutex); }

    /// friends
    template<typename... Args>
    friend auto&& Drop(sync<Args...>&& self);
};

template<typename T>
sync(T) -> sync<T>;

template<typename... Args>
auto&& Drop(sync<Args...>&& self) {
    return std::move(self.data);
}
