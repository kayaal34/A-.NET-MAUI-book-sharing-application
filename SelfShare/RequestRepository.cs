using SQLite;
using SelfShare.Models;

namespace SelfShare
{
    public class RequestRepository
    {
        SQLiteAsyncConnection? _database;

        async Task Init()
        {
            if (_database is not null) return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "SelfShare_Requests.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            await _database.CreateTableAsync<RequestModel>();
        }

        // İSTEK EKLE
        public async Task AddRequestAsync(RequestModel request)
        {
            await Init();
            await _database!.InsertAsync(request);
        }

        // İSTEKLERİ GETİR
        public async Task<List<RequestModel>> GetRequestsAsync()
        {
            await Init();
            return await _database!.Table<RequestModel>().ToListAsync();
        }

        public async Task UpdateRequestAsync(RequestModel request)
        {
            await Init();
            await _database!.UpdateAsync(request);
        }

        // SİLME (Reddedince listeden atmak için)
        public async Task DeleteRequestAsync(RequestModel request)
        {
            await Init();
            await _database!.DeleteAsync(request);
        }
    }
}