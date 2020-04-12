using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TestApp2.Services.Persistance
{
    public interface ISQLLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
