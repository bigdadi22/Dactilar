using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dactilar
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
