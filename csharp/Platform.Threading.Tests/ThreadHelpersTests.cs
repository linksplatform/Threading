using Xunit;

namespace Platform.Threading.Tests
{
    public class ThreadHelpersTests
    {
        [Fact]
        public void InvokeTest()
        {
            var number = 0;
            ThreadHelpers.InvokeWithExtendedMaxStackSize(() => number = 1);
            Assert.Equal(1, number);
            ThreadHelpers.InvokeWithExtendedMaxStackSize(2, (param) => number = (int)param);
            Assert.Equal(2, number);
            ThreadHelpers.InvokeWithModifiedMaxStackSize(() => number = 1, maxStackSize: 512);
            Assert.Equal(1, number);
            ThreadHelpers.InvokeWithModifiedMaxStackSize(2, (param) => number = (int)param, maxStackSize: 512);
            Assert.Equal(2, number);
        }
    }
}
