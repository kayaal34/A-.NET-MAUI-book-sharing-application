using SelfShare.Models;   // Kitap kalıbını kullanacağız
using SelfShare.Services; // Depoya erişeceğiz

namespace SelfShare.Views;

public partial class AddBookPage : ContentPage


{
    string? selectedImageFilePath;

    public AddBookPage()
    {
        InitializeComponent();
    }


    // 2. PARÇA: Fotoğraf kodunu buraya, diğer metodların altına yapıştır
    private async void OnUploadPhotoTapped(object sender, TappedEventArgs e)
    {
        try
        {
            var result = await MediaPicker.Default.PickPhotoAsync();

            if (result != null)
            {
                var newFile = Path.Combine(FileSystem.CacheDirectory, result.FileName);
                using (var stream = await result.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                {
                    await stream.CopyToAsync(newStream);
                }

                selectedImageFilePath = newFile;
                BookImage.Source = ImageSource.FromFile(selectedImageFilePath);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", $"Fotoğraf seçilemedi: {ex.Message}", "Tamam");
        }
    }

    private async void OnAddBookClicked(object sender, EventArgs e)
    {
        // 1. Kontrol: Kitap adı veya yazar girilmemişse uyarı ver
        if (string.IsNullOrWhiteSpace(TitleEntry.Text) || string.IsNullOrWhiteSpace(AuthorEntry.Text))
        {
            await DisplayAlert("Uyarı", "Lütfen en azından Kitap Adı ve Yazar bilgilerini girin.", "Tamam");
            return; // İşlemi durdur
        }

        // 2. Yeni bir Kitap nesnesi oluştur ve verileri içine doldur
        var newBook = new Models.Book
        {
            Title = TitleEntry.Text,
            Author = AuthorEntry.Text,
            Description = DescriptionEditor.Text,
            Condition = ConditionEntry.Text,
            ImageUrl = selectedImageFilePath, // Az önce seçtiğimiz resmin yolu
            OwnerName = "Ben" // Şimdilik sabit yazalım, sonra giriş yapan kullanıcı olacak
        };

        // --- BURASI ÇOK ÖNEMLİ ---
        // Şu an veritabanımız (SQLite) aktif olmadığı için sadece ekranda mesaj göstereceğiz.
        // Bir sonraki adımda buraya "Veritabanına Kaydet" kodunu yazacağız.

        var repo = new BookRepository();

        // 2. Kitabı veritabanına ekle
        await repo.AddBookAsync(newBook);

        // 3. Kullanıcıya bilgi ver
        await DisplayAlert("Başarılı", "Kitabınız rafa eklendi!", "Tamam");

        // 3. Giriş kutularını temizle (İsteğe bağlı)
        TitleEntry.Text = string.Empty;
        AuthorEntry.Text = string.Empty;
        DescriptionEditor.Text = string.Empty;
        ConditionEntry.Text = string.Empty;
        BookImage.Source = "upload_cloud.png"; // Resmi sıfırla

        // 4. Ana Sayfaya Geri Dön
        TitleEntry.Text = string.Empty;
        // ...
        await Shell.Current.GoToAsync("//HomePage");
    }
}
