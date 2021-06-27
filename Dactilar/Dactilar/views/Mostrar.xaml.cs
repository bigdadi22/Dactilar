using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dactilar.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Dactilar.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mostrar : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Productos> _Productos;
        public Mostrar()
        {
            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteDB>().GetConnection();
        }

        private async void btnRegr(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new views.SecondPage(), true);
        }

        protected async override void OnAppearing()
        {
            var ResultRegistros = await _conn.Table<Productos>().ToListAsync();
            _Productos = new ObservableCollection<Productos>(ResultRegistros);
            ListaProductos.ItemsSource = _Productos;
            base.OnAppearing();
        }

        void SlPrd(Object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Productos)e.SelectedItem;
            var item = Obj.Id.ToString();
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushModalAsync(new Eliminar(ID));
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}