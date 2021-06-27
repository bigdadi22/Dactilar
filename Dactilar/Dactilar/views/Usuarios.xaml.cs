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
    public partial class Usuarios : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<User> _User;
        public Usuarios()
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
            var ResultRegistros = await _conn.Table<User>().ToListAsync();
            _User = new ObservableCollection<User>(ResultRegistros);
            ListaUsuarios.ItemsSource = _User;
            base.OnAppearing();
        }

        void SlUsu(Object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (User)e.SelectedItem;
            var item = Obj.Id.ToString();
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushModalAsync(new Elem_User(ID));
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}