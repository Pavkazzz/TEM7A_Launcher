using System.Collections.Generic;
using System.IO;
using Launcher.Core;
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

    public class TestBootstrapper
    {
        [Fact]
        public void testBootstrapper()
        {
            var boot = new AppBootstrapper(Path.GetFullPath(@"..\..\..\..\Modules"));
            Assert.NotNull(boot);
        }
    }
    
    public class TestSql
    {
        [Fact]
        public void testSqlSelect()
        {
            var db = new DataBase(Path.GetFullPath(@"..\..\..\..\Launcher.Core/Db/db.db"));
            var query = @"Select Name, Lastname from Accounts LIMIT 10";
            var column = new List<string> {"Name", "Lastname"};
            var select = db.SqlSelect(query, column);
            Assert.InRange(select.Count, 1, 10);
        }
    }

    public class TestUser
    {
        [Fact]
        public void testRegistrationAndLogin()
        {


        }
    }

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
