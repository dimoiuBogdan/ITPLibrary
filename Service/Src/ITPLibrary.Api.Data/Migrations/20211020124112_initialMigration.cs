using Microsoft.EntityFrameworkCore.Migrations;

namespace ITPLibrary.Api.Data.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NumberOfPages = table.Column<int>(nullable: false),
                    ThumbnailUrl = table.Column<string>(nullable: true),
                    Buyers = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    IsPopular = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { "1", "Fantasy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { "2", "SF" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { "3", "Drama" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Buyers", "CategoryId", "Description", "IsPopular", "NumberOfPages", "Price", "ThumbnailUrl", "Title" },
                values: new object[,]
                {
                    { 1, "JRR Tolkien", 350, "1", "An amazing fantasy book!", true, 420, 50m, "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fblogs.slj.com%2Fafuse8production%2Ffiles%2F2012%2F06%2FHobbit9.jpg&f=1&nofb=1", "Hobbit" },
                    { 2, "Cristopher Nolan", 230, "1", "To galaxy and beyond", true, 200, 30m, "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.platekompaniet.no%2Fglobalassets%2Ffilmcover%2F2015%2Fmars%2Finterstellardvd.jpg&f=1&nofb=1", "Interstellar" },
                    { 4, "JRR Tolkien", 350, "1", "An amazing fantasy book! 2", false, 320, 50m, "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.ictv.org.uk%2Fwp-content%2Fuploads%2F2013%2F01%2FThe-Hobbit.jpg&f=1&nofb=1", "Hobbit 2" },
                    { 5, "Cristopher Nolan", 230, "2", "To galaxy and beyond 2", false, 300, 40m, "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.pandatooth.com%2Fwp-content%2Fuploads%2F2016%2F03%2FInterstellar.jpg&f=1&nofb=1", "Interstellar 2" },
                    { 3, "Invatamantul", 999, "3", "Sadness", true, 999, 999m, "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.ytimg.com%2Fvi%2FYC_MgG7s378%2Fmaxresdefault.jpg&f=1&nofb=1", "Recapitulare bac" },
                    { 6, "Invatamantul", 999, "3", "Sadness 2", false, 399, 499m, "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.christianartgifts.com%2Fproduct-images%2FKJV019_5--featureA.jpg%3Fresizeid%3D5%26resizeh%3D1200%26resizew%3D1200&f=1&nofb=1", "Recapitulare bac 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
