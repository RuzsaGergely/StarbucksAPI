using StarbucksBalance.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VizoraApp.Data;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace StarbucksBalance
{
    public partial class MainPage : ContentPage
    {
        StarbucksData sd;
        RestService rs;
        public MainPage()
        {
            InitializeComponent();

            setGreeting();
            rs = new RestService(Preferences.Get("serverAddress", "NA"));
            getData();
        }

        public void setGreeting()
        {
            DateTime date = DateTime.Now;

            switch (date.Hour)
            {
                case int n when (n >= 5 && n < 12):
                    greeting_field.Text = "Jó reggelt kivánok!";
                    return;
                case int n when (n >= 12 && n < 17):
                    greeting_field.Text = "Jó napot kivánok!";
                    return;
                case int n when (n >= 17 || n < 5):
                    greeting_field.Text = "Jó estét kivánok!";
                    return;
                default:
                    greeting_field.Text = "Öhm... Hello!";
                    return;
            }
        }

        public async void getData()
        {
            sd = await rs.GetStarbucksData();
            this.balance_field.Text = $"{sd.currentAmount} {sd.currency}";
            this.star_field.Text = $"{sd.currentStars} db";
        }

        private void OnSettingsButtonClicked(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            Navigation.PushModalAsync(settings);
        }
    }
}
