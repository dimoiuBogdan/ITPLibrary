﻿namespace ITPLibrary.Api.Core.Dtos
{
    public class BookCreateDto
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