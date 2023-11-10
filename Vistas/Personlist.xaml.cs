using Ejercicio1_3.Models;

namespace Ejercicio1_3.Vistas;

public partial class Personlist : ContentPage
{
    public Personlist()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        listapersonas.ItemsSource = await App.BaseDatos.obtenerPersonlist();
    }

    private async void toolmenu_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Personas persona)
        {
            var action = await DisplayActionSheet($"¿Qué deseas hacer con {persona.Nombres} {persona.Apellidos}?", "Cancelar", null, "Editar", "Borrar");

            if (action == "Borrar")
            {
                var result = await DisplayAlert("Confirmación", $"¿Estás seguro que deseas borrar a {persona.Nombres} {persona.Apellidos}?", "Sí", "No");

                if (result)
                {
                    await App.BaseDatos.PersonDelete(persona);

                    listapersonas.ItemsSource = await App.BaseDatos.obtenerPersonlist();
                }
            }
            else if (action == "Editar")
            {
                await Navigation.PushAsync(new EditPerson(persona));
            }
        }
    }
}
