using RepasoMYSQL.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RepasoMYSQL
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            cambiarNumero();
            bool bd = verifBD();
            DisplayAlert("Mensaje", bd.ToString(), "OK");
            //traerListEmpleados();

            //txtcedula.Text

            //traerUnEmpleado("1102198500183");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //traerListEmpleados();
            cambiarNumero();
        }
        private void cambiarNumero()
        {
            //txtnumero.Text = "10";
        }
        private bool verifBD()
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                byte[] response = cliente.UploadValues(App.ruta + "conexion2.php", "POST", parametros);
                string c = Encoding.ASCII.GetString(response);
                if (c.Equals("1")) return true;
                else return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private async void traerListEmpleados()
        {
            try
            {
                EmpleadoHelper manager = new EmpleadoHelper();
                var res = await manager.getEmpleado();
                if (res != null)
                {
                    lstEmpleado.ItemsSource = res;
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Mensaje de Error", e.Message.ToString(), "OK");
            }
        }
        private async void traerUnEmpleado(string cedula)
        {
            try
            {
                EmpleadoHelper manager = new EmpleadoHelper();
                var res = await manager.traerUnEmpleado(cedula);
                if (res != null)
                {
                    lstEmpleado.ItemsSource = res;
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Mensaje de Error", e.Message.ToString(), "OK");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcedula.Text))
            {

            }
            else traerUnEmpleado(txtcedula.Text);
        }
    }
}
