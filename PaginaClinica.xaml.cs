using System;
using System.Collections.ObjectModel;
using AplicatieMobila.Models;
using Microsoft.Maui.Controls;

namespace AplicatieMobila
{
    public partial class PaginaClinica : ContentPage
    {
        private Clinica clinicaSelectata;
        private ObservableCollection<Interventie> interventiiDisponibile;
        private Interventie interventieSelectata;

        public ObservableCollection<Interventie> InterventiiDisponibile
        {
            get { return interventiiDisponibile; }
            set
            {
                interventiiDisponibile = value;
                OnPropertyChanged(nameof(InterventiiDisponibile));
            }
        }

        public Interventie InterventieSelectata
        {
            get { return interventieSelectata; }
            set
            {
                interventieSelectata = value;
                OnPropertyChanged(nameof(InterventieSelectata));
            }
        }

        public PaginaClinica()
        {
            InitializeComponent();
            BindingContext = new Clinica();
            InterventiiDisponibile = new ObservableCollection<Interventie>();
            InterventieSelectata = new Interventie();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var clinica = (Clinica)BindingContext;

            if (InterventieSelectata != null)
            {
                clinica.InterventieId = InterventieSelectata.Id;
            }

            await App.Database.SaveClinicaAsync(clinica);
            await DisplayClinicListAsync();
            await Navigation.PopAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            InterventiiDisponibile = new ObservableCollection<Interventie>(await App.Database.GetInterventiiAsync());
            pickerInterventii.ItemsSource = InterventiiDisponibile;
            InterventieSelectata = InterventiiDisponibile.FirstOrDefault();

            await DisplayClinicListAsync();
        }
        private async void OnDeleteMenuItemClicked(object sender, EventArgs e)
        {
            if (sender is MenuItem menuItem && menuItem.CommandParameter is Clinica clinicaSelectata)
            {
                await App.Database.DeleteClinicaAsync(clinicaSelectata);
                DisplayClinicListAsync();
            }
        }

        async Task DisplayClinicListAsync()
        {
            var clinicaList = await App.Database.GetCliniciAsync();
            listView.ItemsSource = new ObservableCollection<Clinica>(clinicaList);
        }
    }
}
