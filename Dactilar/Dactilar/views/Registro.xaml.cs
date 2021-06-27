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
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Registro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteDB>().GetConnection();
            
        }

        void btnregistrar(object sender, EventArgs e)
        {
            var DatosRegistro = new User { Username = Etr_user.Text, Password = Etr_pass.Text };
            _conn.InsertAsync(DatosRegistro);
            Navigation.PushModalAsync(new Dactilar.MainPage(), true);
        }

        void btnReg(object sender, EventArgs e)
        {

            Navigation.PushModalAsync(new Dactilar.MainPage(), true);
        }
    }
}