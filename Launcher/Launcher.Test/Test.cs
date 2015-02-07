﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Xunit;

namespace Launcher.Test
{
    public class Test
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }

    public class Bootstrapper
    {
        [Fact]
        public void TestBootstrapper()
        {
            var boot = new AppBootstrapper(Path.GetFullPath(@"../../../Modules"));
            Assert.NotNull(boot);
        }
    }
}
