﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using NLog;

namespace Launcher.Core
{
    public class DataBase
    {
        private readonly string _connectionPath;
        private SQLiteConnection _sqLiteConnectionDatabase;
        //private SQLiteDataAdapter _sqLiteDataAdapter;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DataBase()
        {
            _connectionPath = Path.GetFullPath(@"..\..\..\..\Launcher.Core\Db\db.db");
        }

        public DataBase(string path)
        {
            _connectionPath = path;

            logger.Trace(Path.GetFullPath(_connectionPath));
        }

        private void OpenConnectionSqlite(string path)
        {
            //_sqLiteConnectionDatabase = new SQLiteConnection(string.Format(@"Data Source={0}", path));
            //_sqLiteConnectionDatabase.Open();
            SQLiteConnectionStringBuilder connBuilder = new SQLiteConnectionStringBuilder();
            connBuilder.DataSource = path;
            connBuilder.JournalMode = SQLiteJournalModeEnum.Memory;

            _sqLiteConnectionDatabase = new SQLiteConnection(connBuilder.ToString());
            _sqLiteConnectionDatabase.Open();
        }

        private void CloseConnectionSqlite()
        {
            _sqLiteConnectionDatabase.Close();
        }

        //TODO path
        public List<Dictionary<string, string>> SqlSelect(string sqlQuery, List<string> columnName)
        {
            logger.Trace(sqlQuery);
            OpenConnectionSqlite(_connectionPath);
            var result = new List<Dictionary<string, string>>();
            var sqlSelect = new SQLiteCommand(sqlQuery, _sqLiteConnectionDatabase);
            var sqlReader = sqlSelect.ExecuteReader();
            try
            {
                foreach (DbDataRecord record in sqlReader)
                {
                    var temp = new Dictionary<string, string>();
                    foreach (var column in columnName)
                    {
                        temp.Add(column, record[column].ToString());
                    }
                    result.Add(temp);
                }
            }

            catch (Exception e)
            {
                Debug.WriteLine("Select upal " + e.Message);
            }

            sqlReader.Close();
            CloseConnectionSqlite();
            return result;
        }

        public bool SqlInsert(string sqlQuery)
        {
            try
            {
                OpenConnectionSqlite(_connectionPath);
                var sqlSelect = new SQLiteCommand(sqlQuery, _sqLiteConnectionDatabase);
                var sqlReader = sqlSelect.ExecuteReader();
                sqlReader.Close();
                CloseConnectionSqlite();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SqlDelete(string sqlQuery)
        {
            try
            {
                OpenConnectionSqlite(_connectionPath);
                var sqlSelect = new SQLiteCommand(sqlQuery, _sqLiteConnectionDatabase);
                var sqlReader = sqlSelect.ExecuteReader();
                sqlReader.Close();
                CloseConnectionSqlite();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}