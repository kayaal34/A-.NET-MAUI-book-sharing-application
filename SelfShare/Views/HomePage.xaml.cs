using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace SelfShare.Views;

public partial class HomePage : ContentPage
{
    public ObservableCollection<BookItem> Books { get; set; } = new ObservableCollection<BookItem>();

    public HomePage()
    {
        InitializeComponent();

        // Sample data
        Books.Add(new BookItem { Title = "Sarnýç", Author = "Sait Faik Abasýyanýk", Condition = "New" });
        Books.Add(new BookItem { Title = "War And Peace", Author = "Leo Tolstoy", Condition = "Good" });
        Books.Add(new BookItem { Title = "Sefiller", Author = "Victor Hugo", Condition = "Medium" });
        Books.Add(new BookItem { Title = "Anna Karenina", Author = "Leo Tolstoy", Condition = "Good" });

        BooksCollection.ItemsSource = Books;
    }
}

public class BookItem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Condition { get; set; }
}
