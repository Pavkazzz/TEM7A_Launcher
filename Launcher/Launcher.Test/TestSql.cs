using System.Collections.Generic;
using System.IO;
using Launcher.Core;
using Xunit;

namespace Launcher.Test
{
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
}