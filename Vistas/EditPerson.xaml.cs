using Ejercicio1_3.Models;

namespace Ejercicio1_3.Vistas;

public partial class EditPerson : ContentPage
{
    private Personas persona; 

    public EditPerson(Personas persona)
	{
		InitializeComponent();
        this.persona = persona;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Verifica si la persona recibida es nula
        if (persona != null)
        {
            // Asigna los valores de la persona a los Entry
            txtnombre.Text = persona.Nombres;
            txtapellido.Text = persona.Apellidos;
            txtedad.Text = persona.Edad.ToString();
            txtcorreo.Text = persona.Correo;
            txtdireccion.Text = persona.Direccion;
        }
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

        if (persona != null)
        {
            // Actualiza las propiedades de la persona existente
            persona.Nombres = txtnombre.Text;
            persona.Apellidos = txtapellido.Text;
            persona.Edad = edad;
            persona.Correo = txtcorreo.Text;
            persona.Direccion = txtdireccion.Text;

            var resultado = await App.BaseDatos.PersonSave(persona); // Guarda los cambios en la base de datos

            if (resultado != 0)
            {
                await DisplayAlert("Atencion", "Persona actualizada correctamente!!!", "Ok");
            }
            else
            {
                await DisplayAlert("Atencion", "Upps ha ocurrido un error inesperado", "Ok");
            }
        }
        else
        {
            await DisplayAlert("Atencion", "No se puede actualizar la persona. Datos incorrectos.", "Ok");
        }
    }

    private async void btnSQlite_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}