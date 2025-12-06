using SQLite;
using SelfShare.Models;

namespace SelfShare
{
    public class BookRepository
    {
        SQLiteAsyncConnection? _database;

        // Veritabanı bağlantısını kuran fonksiyon
        async Task Init()
        {
            if (_database is not null)
                return;

            // Veritabanı dosyasını telefonun güvenli klasöründe oluşturur
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "SelfShare_v2.db3");

            _database = new SQLiteAsyncConnection(dbPath);

            // Tabloyu oluştur (Eğer yoksa)
            await _database.CreateTableAsync<Book>();
        }

        // KİTAP EKLEME
        public async Task AddBookAsync(Book book)
        {
            await Init();
            await _database.InsertAsync(book);
        }

        // KİTAPLARI GETİRME (Listeleme)
        public async Task<List<Book>> GetBooksAsync()
        {
            await Init();
            return await _database.Table<Book>().ToListAsync();
        }

        // KİTAP SİLME (İleride lazım olur)
        public async Task DeleteBookAsync(Book book)
        {
            await Init();
            await _database.DeleteAsync(book);
        }
    }
}