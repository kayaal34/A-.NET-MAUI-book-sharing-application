using System;
using Microsoft.Maui.Controls;

namespace SelfShare.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Çýkýþ", "Çýkýþ yapmak istediðinizden emin misiniz?", "Evet", "Hayýr");
            
            if (result)
            {
                // Welcome sayfasýna geri dön
                await Shell.Current.GoToAsync("//Welcome");
            }
        }

        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Ayarlar", "Ayarlar sayfasý yakýnda eklenecek.", "Tamam");
        }
    }
}