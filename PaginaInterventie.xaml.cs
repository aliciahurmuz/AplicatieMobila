using AplicatieMobila.Models;
using System;
using System.Collections.Generic;

namespace AplicatieMobila
{
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
            cosListView.ItemsSource = new List<Interventie>();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var clinica = (Clinica)BindingContext;
            await App.Database.SaveClinicaAsync(clinica);
            await DisplayClinicListAsync();
            await Navigation.PopAsync();
        }
        private async Task DisplayClinicListAsync()
        {
            CliniciDisponibile = await App.Database.GetCliniciAsync();
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
            Interventie interventieSelectata = BindingContext as Interventie;

            if (interventieSelectata != null)
            {
                var sl = new ListaInterventii();
                var lp = new ListaInterventie()
                {
                    ListaInterventiiId = sl.Id,
                    InterventieId = interventieSelectata.Id
                };
                await App.Database.SaveInterventieAsync(interventieSelectata);
                interventieSelectata.Listainterventii = new List<ListaInterventie> { lp };

                var cosItems = cosListView.ItemsSource as List<Interventie>;
                cosItems.Add(interventieSelectata);
                cosListView.ItemsSource = null;
                cosListView.ItemsSource = cosItems;

                await Navigation.PopAsync();
            }
        }
    }
}
