using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using TestApp2.Droid.Service.Persistance.Impl;
using TestApp2.Services.Persistance;


[assembly: Dependency(typeof(SQLiteDb))]

namespace TestApp2.Droid.Service.Persistance.Impl
{
    public class SQLiteDb : ISQLLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLiteDb.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}
