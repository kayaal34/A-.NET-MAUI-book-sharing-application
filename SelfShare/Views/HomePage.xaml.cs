using SelfShare.Models;
using System.Linq; // Arama ve kontrol işlemleri için gerekli

namespace SelfShare.Views;

public partial class HomePage : ContentPage
{
    // Arama yaparken tüm kitapları burada tutacağız
    private List<Book> _allBooks = new List<Book>();

    public HomePage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var repo = new BookRepository();

        // 1. Veritabanındaki mevcut kitapları çek
        _allBooks = await repo.GetBooksAsync();

        bool newDataAdded = false;

        // --- DEMİRBAŞ KİTAPLARI KONTROL ET VE EKLE ---
        // Not: If bloklarını ayırdık, artık hepsi tek tek kontrol ediliyor.

        // 1. War and Peace
        if (!_allBooks.Any(b => b.Title == "War and Peace"))
        {
            await repo.AddBookAsync(new Book
            {
                Title = "War and Peace",
                Author = "Leo Tolstoy",
                Condition = "Good",
                Description = "Klasik bir eser.",
                OwnerName = "Sistem",
                ImageUrl = "war.png" // Senin dosya adın
            });
            newDataAdded = true;
        }

        // 2. Sarnıç
        if (!_allBooks.Any(b => b.Title == "Sarnıç"))
        {
            await repo.AddBookAsync(new Book
            {
                Title = "Sarnıç",
                Author = "Sait Faik Abasıyanık",
                Condition = "Medium",
                Description = "Hikaye kitabı.",
                OwnerName = "Sistem",
                ImageUrl = "sarnic.png" // Senin dosya adın
            });
            newDataAdded = true;
        }

        // 3. Sefiller
        if (!_allBooks.Any(b => b.Title == "Sefiller"))
        {
            await repo.AddBookAsync(new Book
            {
                Title = "Sefiller",
                Author = "Victor Hugo",
                Condition = "Medium",
                Description = "Fransız edebiyatının en önemli eserlerinden.",
                OwnerName = "Sistem",
                ImageUrl = "sefiller.png" // Senin dosya adın
            });
            newDataAdded = true;
        }

        // 4. Anna Karenina
        if (!_allBooks.Any(b => b.Title == "Anna Karenina"))
        {
            await repo.AddBookAsync(new Book
            {
                Title = "Anna Karenina",
                Author = "Leo Tolstoy",
                Condition = "Good",
                Description = "Rus edebiyatının başyapıtı.",
                OwnerName = "Sistem",
                ImageUrl = "annakarenina.png" // Senin dosya adın
            });
            newDataAdded = true;
        }

        // Eğer yeni kitap eklediysek listeyi tekrar tazeleyelim ki ekranda görünsün
        if (newDataAdded)
        {
            _allBooks = await repo.GetBooksAsync();
        }

        // Listeyi ekrana bas
        BooksCollection.ItemsSource = _allBooks;
    }

    // --- ARAMA KUTUSU ÇALIŞMA MANTIĞI ---
    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        var searchTerm = e.NewTextValue;

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            // Arama kutusu boşsa hepsini göster
            BooksCollection.ItemsSource = _allBooks;
        }
        else
        {
            // Arama kutusu doluysa, Kitap Adı VEYA Yazar Adı eşleşenleri filtrele
            var filteredBooks = _allBooks.Where(b =>
                (b.Title != null && b.Title.ToLower().Contains(searchTerm.ToLower())) ||
                (b.Author != null && b.Author.ToLower().Contains(searchTerm.ToLower()))
            ).ToList();

            BooksCollection.ItemsSource = filteredBooks;
        }
    }
    private async void OnSendRequestClicked(object sender, EventArgs e)
    {
        // Tıklanan butonu bul
        var button = (Button)sender;

        // Butonun taşıdığı kitap bilgisini al
        var selectedBook = (Models.Book)button.CommandParameter;

        if (selectedBook == null) return;

        bool answer = await DisplayAlert("İstek Gönder", $"{selectedBook.Title} kitabı için istek göndermek istiyor musun?", "Evet", "Hayır");

        if (answer)
        {
            var newRequest = new Models.RequestModel
            {
                Title = selectedBook.Title,
                UserName = selectedBook.OwnerName,
                ImageUrl = selectedBook.ImageUrl,
                Status = "Pending",
                IsIncoming = false
            };

            var repo = new RequestRepository();
            await repo.AddRequestAsync(newRequest);

            await DisplayAlert("Başarılı", "İsteğin gönderildi! Requests sayfasından takip edebilirsin.", "Tamam");
        }
    }
}