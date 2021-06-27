using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dactilar.Models;
using SQLite;
using System.IO;


namespace Dactilar
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public MainPage()
        {
            InitializeComponent();

           _conn = DependencyService.Get<ISQLiteDB>().GetConnection();

            
        }

        public static IEnumerable<User> SELECT_WHERE(SQLiteConnection db, string Username, string Password)
        {
            return db.Query<User>("SELECT * FROM User where Username= ? and Password = ?", Username, Password);

        }
        void SignInProcedure(object sender, EventArgs e)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MySQLite.db3");
            var db = new SQLiteConnection(databasePath);
            IEnumerable<User> resultado = SELECT_WHERE(db, Entry_Username.Text, Entry_Password.Text);
            if (resultado.Count() > 0)
            {
                Navigation.PushModalAsync(new views.SecondPage());
            }
            else
            {
                DisplayAlert("BOX", "Verifique su Usuario/Contraseña", "OK");
            }
        }

        void btnreg(object sender, EventArgs e)
        {

                Navigation.PushModalAsync(new views.Registro(), true);
        }




    }
}
