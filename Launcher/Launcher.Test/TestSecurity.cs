using Launcher.Core;
using Xunit;

namespace Launcher.Test
{
    public class TestSecurity
    {
        [Fact]
        public void TestSha512()
        {
            var firstSha512 = Security.GetSHA512("admin");
            var secondSha512 = Security.GetSHA512("admin");
            Assert.NotNull(firstSha512);
            Assert.Equal(firstSha512, secondSha512);
        }
    }
}