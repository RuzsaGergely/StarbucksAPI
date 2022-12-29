using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials;


namespace StarbucksBalance
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            addressField.Text = Preferences.Get("serverAddress", "");
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Preferences.Set("serverAddress", addressField.Text);
            await DisplayAlert("Cim mentése", "Sikeres mentés! Inditsd újra kérlek az alkalmazást!", "OK");
        }
    }
}