using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace S5Acosta
{
    public partial class MainPage : ContentPage
    {
        private const string url = "http://192.168.0.113/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<S5Acosta.Ws.Datos> _post;
        private int id = 0;
        private string nombre = null;
        private string apellido = null;
        private int edad = 0;

        public MainPage()
        {
            InitializeComponent();
            llenarTabla();
        }
        private async void llenarTabla()
        {
            var content = await client.GetStringAsync(url);
            List<S5Acosta.Ws.Datos> posts = JsonConvert.DeserializeObject<List<S5Acosta.Ws.Datos>>(content);
            _post = new ObservableCollection<S5Acosta.Ws.Datos>(posts);
            postListView.ItemsSource = _post;
        }
        private async void BtonPost_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new viewInsertarB());
        }

        private async void postListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var sel = ((ListView)sender).SelectedItem as S5Acosta.Ws.Datos;
            if (sel == null)
                return;
            id = sel.codigo;
            nombre = sel.nombre;
            apellido = sel.aellido;
            edad = sel.edad;

            //await DisplayAlert("Seleccionado", Convert.ToString(id)+" "+nombre+" "+apellido+" "+edad, "ok");


        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {

        }

        private void listCell_Tapped(object sender, EventArgs e)
        {

        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (id == 0 & nombre == null & apellido == null & edad == 0)
                {
                    await DisplayAlert("Error", "Debe seleccionar una fila", "Ok");
                }
                else
                {
                    //  await DisplayAlert("Seleccionado", Convert.ToString(id) + " " + nombre + " " + apellido + " " + edad, "ok");
                    await Navigation.PushAsync(new editar(id, nombre, apellido, edad));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            if (id == 0 & nombre == null & apellido == null & edad == 0)
            {
                await DisplayAlert("Error", "Debe seleccionar una fila", "Ok");
            }
            else
            {
                //  await DisplayAlert("Seleccionado", Convert.ToString(id) + " " + nombre + " " + apellido + " " + edad, "ok");
                await Navigation.PushAsync(new eliminar(id, nombre, apellido));
            }
        }
    }
}
