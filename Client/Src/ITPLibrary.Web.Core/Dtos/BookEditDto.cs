namespace ITPLibrary.Web.Core.Dtos
{
    public class BookEditDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int NumberOfPages { get; set; }
        public string ThumbnailUrl { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
