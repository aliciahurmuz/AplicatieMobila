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
            var result = await DisplayAlert("Confirmare", $"Sigur dori?i s? ?terge?i clinica {selectedClinic.Nume}?", "Da", "Nu");

            if (result)
            {
                await App.Database.DeleteClinicaAsync(selectedClinic);
                await DisplayAlert("Clinic? ?tears?", $"Clinica {selectedClinic.Nume} a fost ?tears? cu succes.", "OK");
                await RefreshClinicListAsync();
            }
        }
        else
        {
            await DisplayAlert("Eroare", "V? rug?m s? selecta?i o clinic? pentru a o ?terge.", "OK");
        }
    }

    async Task RefreshClinicListAsync()
    {
        listView.ItemsSource = await App.Database.GetCliniciAsync();
    }
}