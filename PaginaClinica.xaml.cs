using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AplicatieMobila.Models;
using Microsoft.Maui.Controls;

namespace AplicatieMobila
{
    public partial class PaginaClinica : ContentPage
    {
        private Clinica clinicaSelectata;
        public ICommand DeleteCommand { get; private set; }

        public PaginaClinica()
        {
            InitializeComponent();
            BindingContext = new Clinica();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var clinica = (Clinica)BindingContext;

            await App.Database.SaveClinicaAsync(clinica);
            await DisplayClinicListAsync();
            await Navigation.PopAsync();
        }

        async Task DisplayClinicListAsync()
        {
            var clinicaList = await App.Database.GetCliniciAsync();
            listView.ItemsSource = new ObservableCollection<Clinica>(clinicaList);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
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


    }
}
