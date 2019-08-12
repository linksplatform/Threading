using System.Threading.Tasks;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Threading
{
    public static class TaskExtensions
    {
        public static T AwaitResult<T>(this Task<T> task) => task.GetAwaiter().GetResult();
    }
}
