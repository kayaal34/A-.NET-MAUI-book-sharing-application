using System.Collections.ObjectModel;
using SelfShare.Models; // Az önce oluşturduğun Book modelini içeri alıyoruz

namespace SelfShare.Services
{
    public static class BookRepository
    {
        // ObservableCollection: Bu listenin özelliği, içine veri eklenince ekranı otomatik yenilemesidir.
        public static ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>()
        {
            // --- BAŞLANGIÇ VERİLERİ (UYGULAMA BOŞ GÖRÜNMESİN DİYE) ---
            new Book
            {
                Title = "Calculus 101",
                Author = "Liam Harper",
                Condition = "New",
                OwnerName = "Liam",
                ImageUrl = "book_calculus.png" // Resim yoksa boş çıkar, sorun değil
            },
            new Book
            {
                Title = "Organik Kimya",
                Author = "Prof. Oktay Sinanoğlu",
                Condition = "Good",
                OwnerName = "Ayşe",
                ImageUrl = "book_chemistry.png"
            },
            new Book
            {
                Title = "Sefiller",
                Author = "Victor Hugo",
                Condition = "Old",
                OwnerName = "Mehmet",
                ImageUrl = "book_placeholder.png"
            }
        };

        // Yeni kitap eklemek için kullanılacak metot
        public static void AddBook(Book newBook)
        {
            Books.Add(newBook);
        }
    }
}