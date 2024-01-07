using AplicatieMobila;
using AplicatieMobila.Models;

namespace AplicatieMobila;

public partial class ListaPagina : ContentPage
{
	public ListaPagina()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ListaInterventii)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveListaInterventiiAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ListaInterventii)BindingContext;
        await App.Database.DeleteListaInterventiiAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        ListaInterventii listaInterventii = (ListaInterventii)this.BindingContext;
        Interventie interventie = new Interventie
        {
            Denumire = listaInterventii.Denumire, 
        };

        await Navigation.PushAsync(new PaginaInterventie(interventie)
        {
            BindingContext = interventie
        });
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var interv = (ListaInterventii)BindingContext;
        listView.ItemsSource = await App.Database.GetListeInterventiiAsync();
    }

}
