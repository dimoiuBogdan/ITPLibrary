namespace ITPLibrary.Web.Core.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int NumberOfPages { get; set; }
        public string ThumbnailUrl { get; set; }
        public int Buyers { get; set; }
        public decimal Price { get; set; }
        public bool IsPopular { get; set; }
        public string CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
