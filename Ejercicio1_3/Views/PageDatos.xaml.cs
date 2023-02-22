using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Ejercicio1_3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDatos : ContentPage
    {
        public PageDatos()
        {
            InitializeComponent();
        }

        private async void btnsalvar_Clicked(object sender, EventArgs e)
        {
            var data = new Models.Datos
            {
                Nombre = nombre.Text,
                Apellidos = apellidos.Text,
                Edad = edad.Text,
                Correo = correo.Text,
                Direccion = direccion.Text
            };

            if (await App.DBdatos.StoreDatos(data) > 0)
            {
                await DisplayAlert("Aviso", "Ingresado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "Error ", "OK");
            }

        }

    }
}