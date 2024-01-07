using AplicatieMobila.Models;
namespace AplicatieMobila;

public partial class PaginaInterventie : ContentPage
{
    Interventie interv;
    Interventie sl;
    public List<Clinica> CliniciDisponibile { get; set; }
    public PaginaInterventie(Interventie slist)
    {
        InitializeComponent();
        sl = slist;
        CliniciDisponibile = new List<Clinica>();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        interv = (Interventie)BindingContext;
        await App.Database.SaveInterventieAsync(interv);
        listView.ItemsSource = await App.Database.GetInterventiiAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        interv = (Interventie)BindingContext;
        await App.Database.DeleteInterventieAsync(interv);
        listView.ItemsSource = await App.Database.GetInterventiiAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CliniciDisponibile = await App.Database.GetCliniciAsync();
        listView.ItemsSource = await App.Database.GetInterventiiAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Interventie p;

        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Interventie;
            var sl = new ListaInterventii();
            var lp = new ListaInterventie()
            {
                ListaInterventiiId = sl.Id,
                InterventieId = p.Id
            };
            await App.Database.SaveInterventieAsync(interv);
            p.Listainterventii = new List<ListaInterventie> { lp };
            await Navigation.PopAsync();
        }
    }
}
