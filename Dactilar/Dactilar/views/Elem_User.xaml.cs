using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dactilar.Models;
using SQLite;
using System.IO;

namespace Dactilar.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elem_User : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection _conn;
        IEnumerable<User> ResultDelete;
        IEnumerable<User> ResultUpdate;
        public Elem_User(int id)
        {
            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteDB>().GetConnection();
            IdSeleccionado = id;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            mensaje.Text = "Se afectara el ID[" + IdSeleccionado + "]";
        }

        private async void btnRegr(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new views.SecondPage(), true);
        }

        private void btnEli(object sender, EventArgs e)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //Se crea la BD
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            var dbUser = new SQLiteConnection(path);
            ResultDelete = Delete(dbUser, IdSeleccionado);
            DisplayAlert("Delete", "Se Elimino el Usuario", "OK");
            Navigation.PushModalAsync(new views.Usuarios(), true);
        }

        private void btnAct(object sender, EventArgs e)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //Se crea la BD
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            var dbProd = new SQLiteConnection(path);
            ResultUpdate = Update(dbProd, nomUsu.Text, conUsu.Text, IdSeleccionado);
            DisplayAlert("Update", "Se actualizaso el producto", "OK");
            Navigation.PushModalAsync(new views.Usuarios(), true);
        }

        public static IEnumerable<User> Delete(SQLiteConnection db, int id)
        {
            return db.Query<User>("DELETE FROM User where Id=?", id);
        }

        public static IEnumerable<User> Update(SQLiteConnection db, string Username, string Password, int Id)
        {
            return db.Query<User>("UPDATE User SET Username=?, Password=? where Id=?", Username, Password, Id);
        }
    }
}