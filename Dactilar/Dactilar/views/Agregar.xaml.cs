using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dactilar.Models;

namespace Dactilar.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agregar : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Agregar()
        {
            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteDB>().GetConnection();
        }
        void btnRegr(object sender, EventArgs e)
        {

            Navigation.PushModalAsync(new views.SecondPage(), true);
        }

        void btnAgr(object sender, EventArgs e)
        {
            var DatosRegistro = new Productos { NomPrd = nomPro.Text, CantPrd = Convert.ToInt32(canPro.Text), CostPrd = Convert.ToInt32(prePro.Text)};
            _conn.InsertAsync(DatosRegistro);
            Navigation.PushModalAsync(new views.SecondPage(), true);

        }
    }
}