using Ejercicio1_3.Models;

namespace Ejercicio1_3
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            int edad = Convert.ToInt32(txtedad.Text);

            if (string.IsNullOrWhiteSpace(txtnombre.Text) || string.IsNullOrWhiteSpace(txtapellido.Text) ||
                string.IsNullOrWhiteSpace(txtedad.Text) || string.IsNullOrWhiteSpace(txtcorreo.Text) ||
                string.IsNullOrWhiteSpace(txtdireccion.Text))
            {
                await DisplayAlert("Atencion", "Por favor, completa todos los campos.", "Ok");
                return; 
            }

            var persona = new Personas
            {
                
                Nombres = txtnombre.Text,
                Apellidos = txtapellido.Text,
                Edad = edad,
                Correo = txtcorreo.Text,
                Direccion = txtdireccion.Text
            };

            var resultado = await App.BaseDatos.PersonSave(persona);

            if (resultado != 0)
            {
                await DisplayAlert("Atencion", "Persona ingresada correctamente!!!", "Ok");
            }
            else
            {
                await DisplayAlert("Atencion", "Upps ha ocurrido un error inesperado", "Ok");
            }
        }

        private async void btnSQlite_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}