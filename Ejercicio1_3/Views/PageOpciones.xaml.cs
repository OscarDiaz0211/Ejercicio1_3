using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageOpciones : ContentPage
    {
        public PageOpciones()
        {
            InitializeComponent();
        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            var data = new Models.Datos
            {
                Id = Int32.Parse(id.Text),
                Nombre = nombre.Text,
                Apellidos = apellidos.Text,
                Edad = edad.Text,
                Correo = correo.Text,
                Direccion = direccion.Text
            };

            if (await App.DBdatos.StoreDatos(data) > 0)
            {
                await DisplayAlert("Aviso", "Actualizados con exito", "OK");

                id.Text = "";
                nombre.Text = "";
                apellidos.Text = "";
                edad.Text = "";
                correo.Text = "";
                direccion.Text = "";

                await Navigation.PushAsync(new Views.PagePrincipal());
            }
            else
            {
                await DisplayAlert("Error", "Error", "OK");
            }
        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            OnAlertYesNoClicked(sender, e);
        }

        async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Alerta!", "Desea eliminar los datos?", "Si", "No");
            

            if (answer == true)
            {
                var data = new Models.Datos
                {
                    Id = Int32.Parse(id.Text)
                };

                if (await App.DBdatos.DeleteDatos(data) > 0)
                {
                    await DisplayAlert("Aviso", "eliminados con exito", "OK");

                    id.Text = "";
                    nombre.Text = "";
                    apellidos.Text = "";
                    edad.Text = "";
                    correo.Text = "";
                    direccion.Text = "";

                    await Navigation.PushAsync(new Views.PagePrincipal());
                }
                else
                {
                    await DisplayAlert("Error", "Error", "OK");
                }
            
            }
            
        }
    }
}