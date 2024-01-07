using AplicatieMobila.Models;

namespace AplicatieMobila;

public partial class Lista1 : ContentPage
{
    public Lista1()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetListeInterventiiAsync();
    }

    async void OnListaInterventiiAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaPagina
        {
            BindingContext = new ListaInterventii()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ListaPagina
            {
                BindingContext = e.SelectedItem as ListaInterventii
            });
        }
    }
}

