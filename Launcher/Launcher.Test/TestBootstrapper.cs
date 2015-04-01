using System.IO;
using Xunit;

namespace Launcher.Test
{
    public class TestBootstrapper
    {
        [Fact]
        public void testBootstrapper()
        {
            var boot = new AppBootstrapper(Path.GetFullPath(@"..\..\..\..\Modules"));
            Assert.NotNull(boot);
        }
    }
}