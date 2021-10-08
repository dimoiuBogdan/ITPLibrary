using ITPLibrary.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITPLibrary.Api.Data.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                CategoryId = 1,
                CategoryName = "Fantasy"
            });

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                CategoryId = 2,
                CategoryName = "SF"
            });

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                CategoryId = 3,
                CategoryName = "Drama"
            });

            modelBuilder.Entity<Book>().HasData(new Book()
            {
                BookId = 1,
                Title = "Hobbit",
                ThumbnailUrl = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fblogs.slj.com%2Fafuse8production%2Ffiles%2F2012%2F06%2FHobbit9.jpg&f=1&nofb=1",
                Description = "An amazing fantasy book!",
                Author = "JRR Tolkien",
                NumberOfPages = 420,
                Price = 50,
                IsPopular = true,
                Buyers = 350,
                CategoryId=1
            });

            modelBuilder.Entity<Book>().HasData(new Book()
            {
                BookId = 2,
                Title = "Interstellar",
                ThumbnailUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.platekompaniet.no%2Fglobalassets%2Ffilmcover%2F2015%2Fmars%2Finterstellardvd.jpg&f=1&nofb=1",
                Description = "To galaxy and beyond",
                Author = "Cristopher Nolan",
                NumberOfPages = 200,
                Price = 30,
                IsPopular = true,
                Buyers = 230,
                CategoryId = 2
            });

            modelBuilder.Entity<Book>().HasData(new Book()
            {
                BookId = 3,
                Title = "Recapitulare bac",
                ThumbnailUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.ytimg.com%2Fvi%2FYC_MgG7s378%2Fmaxresdefault.jpg&f=1&nofb=1",
                Description = "Sadness",
                Author = "Invatamantul",
                NumberOfPages = 999,
                Price = 999,
                IsPopular = true,
                Buyers = 999,
                CategoryId = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book()
            {
                BookId = 4,
                Title = "Hobbit 2",
                ThumbnailUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.ictv.org.uk%2Fwp-content%2Fuploads%2F2013%2F01%2FThe-Hobbit.jpg&f=1&nofb=1",
                Description = "An amazing fantasy book! 2",
                Author = "JRR Tolkien",
                NumberOfPages = 320,
                Price = 50,
                IsPopular = false,
                Buyers = 350,
                CategoryId = 1
            });

            modelBuilder.Entity<Book>().HasData(new Book()
            {
                BookId = 5,
                Title = "Interstellar 2",
                ThumbnailUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.pandatooth.com%2Fwp-content%2Fuploads%2F2016%2F03%2FInterstellar.jpg&f=1&nofb=1",
                Description = "To galaxy and beyond 2",
                Author = "Cristopher Nolan",
                NumberOfPages = 300,
                Price = 40,
                IsPopular = false,
                Buyers = 230,
                CategoryId = 2
            });

            modelBuilder.Entity<Book>().HasData(new Book()
            {
                BookId = 6,
                Title = "Recapitulare bac 2",
                ThumbnailUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.christianartgifts.com%2Fproduct-images%2FKJV019_5--featureA.jpg%3Fresizeid%3D5%26resizeh%3D1200%26resizew%3D1200&f=1&nofb=1",
                Description = "Sadness 2",
                Author = "Invatamantul",
                NumberOfPages = 399,
                Price = 499,
                IsPopular = false,
                Buyers = 999,
                CategoryId = 3
            });
        }

    }
}
