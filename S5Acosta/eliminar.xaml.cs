using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S5Acosta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class eliminar : ContentPage
    {
        private HttpClient client;
        private int pk = 0;
        public eliminar(int id, string nombre, string apellido)
        {
            InitializeComponent();
            pregunta.Text = "Estas seguro de eliminar " + id + ": " + nombre + apellido;
            pk = id;
        }

        private async void BtnSi_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (pk == 0)
                {
                    await DisplayAlert("Error", "No existe la llave primaria", "Ok");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    client = new HttpClient();
                    await client.DeleteAsync("http://192.168.0.113/moviles/post.php?codigo=" + pk);
                    await DisplayAlert("Eliminado", "Se elimino Correctamente", "Ok");
                    await Navigation.PushAsync(new MainPage());

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async void BtnNo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}