namespace SelfShare.Models // Eğer klasör içinde değilse ".Models" kısmını sil
{
    public class Book
    {
        public string? Title { get; set; }        // Soru işareti (?) null olabilir demek
        public string? Author { get; set; }
        public string? Condition { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? OwnerName { get; set; }
    }
}