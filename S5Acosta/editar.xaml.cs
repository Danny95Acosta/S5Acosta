using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S5Acosta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class editar : ContentPage
    {
        public editar(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            txtCodigo.Text = Convert.ToString(codigo);
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = Convert.ToString(edad);
        }

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.0.113/moviles/post.php?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);
                DisplayAlert("alerta", "Guardado correctamente", "ok");
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("alerta", ex.Message, "OK");
            }
        }

        private void BtnAtras_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}