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
    public partial class Eliminar : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection _conn;
        IEnumerable<Productos> ResultDelete;
        IEnumerable<Productos> ResultUpdate;
        public Eliminar(int id)
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
            var dbProd = new SQLiteConnection(path);
            ResultDelete = Delete(dbProd,IdSeleccionado);
            DisplayAlert("Delete", "Se Elimino el producto", "OK");
            Navigation.PushModalAsync(new views.Mostrar(), true);
        }

        private void btnAct(object sender, EventArgs e)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //Se crea la BD
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            var dbProd = new SQLiteConnection(path);
            ResultUpdate = Update(dbProd, nomPrd.Text, Convert.ToInt32(canPrd.Text), Convert.ToInt32(cosPrd.Text),IdSeleccionado);
            DisplayAlert("Update", "Se actualizaso el producto", "OK");
            Navigation.PushModalAsync(new views.Mostrar(), true);
        }

        public static IEnumerable<Productos> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Productos>("DELETE FROM Productos where Id=?", id);
        }

        public static IEnumerable<Productos> Update(SQLiteConnection db, string NomPrd, int CantPrd, int CostPrd, int Id)
        {
            return db.Query<Productos>("UPDATE Productos SET NomPrd=?, CantPrd=?, CostPrd=? where Id=?", NomPrd, CantPrd, CostPrd, Id);
        }
    }
}