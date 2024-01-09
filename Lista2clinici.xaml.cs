using AplicatieMobila.Models;

namespace AplicatieMobila;

public partial class Lista2clinici : ContentPage
{
	public Lista2clinici()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetCliniciAsync();
    }
    async void OnShopAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaClinica
        {
            BindingContext = new Clinica()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new PaginaClinica
            {
                BindingContext = e.SelectedItem as Clinica
            });
        }
    }

    async void OnDeleteSelectedClinicClicked(object sender, EventArgs e)
    {
        var selectedClinic = (Clinica)listView.SelectedItem;

        if (selectedClinic != null)
        {
            var result = await DisplayAlert("Confirmare", $"Sigur doriti sa stergeti clinica {selectedClinic.Nume}?", "Da", "Nu");

            if (result)
            {
                await App.Database.DeleteClinicaAsync(selectedClinic);
                await DisplayAlert("Clinica atearsa", $"Clinica {selectedClinic.Nume} a fost stearsa cu succes.", "OK");
                await RefreshClinicListAsync();
            }
        }
        else
        {
            await DisplayAlert("Eroare", "Va rugam sa selectati o clinica pentru a o sterge.", "OK");
        }
    }

    async Task RefreshClinicListAsync()
    {
        listView.ItemsSource = await App.Database.GetCliniciAsync();
    }
}