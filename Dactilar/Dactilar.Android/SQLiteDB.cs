using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dactilar.Droid;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using Dactilar.Models;
[assembly: Dependency(typeof(SQLiteDB))]

namespace Dactilar.Droid
{
    public class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //Se crea la BD
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            var dbUser = new SQLiteConnection(path);
            dbUser.CreateTable<User>();

            var dbProd = new SQLiteConnection(path);
            dbProd.CreateTable<Productos>();

            return new SQLiteAsyncConnection(path);
        }
    }
}