using SQLite;

namespace SelfShare.Models
{
    public class RequestModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string? Title { get; set; }     // ? Eklendi
        public string? UserName { get; set; }  // ? Eklendi
        public string? ImageUrl { get; set; }  // ? Eklendi
        public string? Status { get; set; }    // ? Eklendi

        public bool IsIncoming { get; set; }
        public bool IsOutgoing => !IsIncoming;
    }
}