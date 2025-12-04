using System;
using Microsoft.Maui.Controls;

namespace SelfShare.Views
{
    public partial class SignUpPage : ContentPage
    {
        private bool isPasswordVisible = false;
        private bool isConfirmPasswordVisible = false;

        public SignUpPage()
        {
            InitializeComponent();
        }

        private void OnPasswordEyeClicked(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            PasswordEntry.IsPassword = !isPasswordVisible;
            PasswordEye.Source = isPasswordVisible ? "eye_open.png" : "eye_closed.png";
        }

        // 2. Şifre Tekrar Gözü
        private void OnConfirmPasswordEyeClicked(object sender, EventArgs e)
        {
            isConfirmPasswordVisible = !isConfirmPasswordVisible;
            ConfirmPasswordEntry.IsPassword = !isConfirmPasswordVisible;
            ConfirmPasswordEye.Source = isConfirmPasswordVisible ? "eye_open.png" : "eye_closed.png";
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            // 1. Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
                string.IsNullOrWhiteSpace(EmailEntry.Text) ||
                string.IsNullOrWhiteSpace(PasswordEntry.Text) ||
                string.IsNullOrWhiteSpace(ConfirmPasswordEntry.Text))
            {
                await DisplayAlert("Hata", "Lütfen tüm alanları doldurunuz.", "Tamam");
                return;
            }

            // 2. Şifre uyuşmazlığı kontrolü
            if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
            {
                await DisplayAlert("Hata", "Şifreler birbiriyle uyuşmuyor.", "Tamam");
                return;
            }

            // 3. Başarılı Kayıt (placeholder)
            bool answer = await DisplayAlert("Başarılı", "Kayıt oluşturuldu! Giriş yapmak ister misiniz?", "Evet", "Hayır");

            if (answer)
            {
                // Login sayfasına yönlendirme
                try
                {
                    await Shell.Current.GoToAsync(nameof(LoginPage));
                }
                catch
                {
                    // Fallback: klasik Navigation
                    try
                    {
                        await Navigation.PushAsync(new LoginPage());
                    }
                    catch
                    {
                        // ignore
                    }
                }
            }
        }

        private async void OnLoginRedirectClicked(object sender, EventArgs e)
        {
            // "Log In" yazısına basınca LoginPage'e git
            try
            {
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
            catch
            {
                try
                {
                    await Navigation.PushAsync(new LoginPage());
                }
                catch
                {
                    await DisplayAlert("Bilgi", "Yönlendirme yapılamadı. Route kaydını kontrol edin.", "Tamam");
                }
            }
        }

        private async void OnSignUpRedirectClicked(object sender, EventArgs e)
        {
            // Bu zaten SignUp sayfası, bu metod gereksiz olabilir ama eklendi
            await DisplayAlert("Bilgi", "Zaten kayıt sayfasındasınız.", "Tamam");
        }
    }
}