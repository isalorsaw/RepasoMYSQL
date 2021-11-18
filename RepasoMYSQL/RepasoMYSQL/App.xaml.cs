using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RepasoMYSQL
{
    public partial class App : Application
    {
        public static string ruta;
        public App()
        {
            InitializeComponent();
            ruta = "https://uthprograweb2.000webhostapp.com/webservice/";
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
