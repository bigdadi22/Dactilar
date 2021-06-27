using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dactilar.iOS;
using Xamarin.Forms;
using Foundation;
using UIKit;
using SQLite;
using System.IO;

[assembly: Dependency(typeof(SQLiteDB))]

namespace Dactilar.iOS
{
    public class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //Se crea la base de datos
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}