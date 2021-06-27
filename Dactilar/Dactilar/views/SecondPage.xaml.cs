using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dactilar.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private async void btnagr(object sender, EventArgs e)
        {

                await Navigation.PushModalAsync(new views.Agregar(), true);
        }


        private async void btnmos(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new views.Mostrar(), true);
        }

        private async void btnreg(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new Dactilar.MainPage(), true);
        }

        private async void btnusu(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new views.Usuarios(), true);
        }

    }
}