using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Cache;
using System.Data.SqlTypes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

namespace S5Acosta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewInsertarB : ContentPage
    {
        public viewInsertarB()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.0.113/moviles/post.php", "POST", parametros);
                DisplayAlert("alerta", "ingreso correcto", "ok");
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("alerta", ex.Message, "OK");
            }
        }

        private void BtnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());

        }
    }
}