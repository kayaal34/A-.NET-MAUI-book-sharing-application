namespace SelfShare.Views;

public partial class LoginPage : ContentPage
{
    // Şifrenin görünüp görünmediğini takip eden değişken
    private bool isPasswordVisible = false;

    public LoginPage()
    {
        InitializeComponent();
    }

    private void OnEyeIconClicked(object sender, EventArgs e)
    {
        isPasswordVisible = !isPasswordVisible;
        PasswordEntry.IsPassword = !isPasswordVisible;

        if (isPasswordVisible)
        {
            // Şifre AÇIK ise -> Üstteki normal göz resmini göster
            // "eye_open.png" dosyasını Resources/Images içine atmış olman lazım!
            EyeIcon.Source = "eye_open.png";
        }
        else
        {
            // Şifre KAPALI ise -> Alttaki çizik göz resmini göster
            EyeIcon.Source = "eye_closed.png";
        }
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Basit bir boş kontrolü yapalım
        if (string.IsNullOrWhiteSpace(EmailEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlert("Hata", "Lütfen email ve şifre giriniz.", "Tamam");
            return;
        }

        // Giriş başarılı simülasyonu
        await DisplayAlert("Başarılı", $"Hoşgeldin, {EmailEntry.Text}!", "Tamam");

        // Ana sayfalara (TabBar) yönlendirme
        await Shell.Current.GoToAsync("//MainTabs");
    }

    private async void OnForgotPasswordClicked(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Bilgi", "Şifre sıfırlama ekranına gidilecek.", "Tamam");
    }

    private async void OnSignUpRedirectClicked(object sender, EventArgs e)
    {
        // "Sign Up" yazısına basınca SignUpPage'e git
        try
        {
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }
        catch
        {
            try
            {
                await Navigation.PushAsync(new SignUpPage());
            }
            catch
            {
                await DisplayAlert("Bilgi", "Yönlendirme yapılamadı. Route kaydını kontrol edin.", "Tamam");
            }
        }
    }
}