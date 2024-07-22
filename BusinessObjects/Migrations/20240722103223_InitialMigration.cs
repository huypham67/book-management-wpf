using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BookCarts",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookGenreType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCarts", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    BookCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookGenreType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.BookCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BookDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    BookCategoryId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_BookCategories_BookCategoryId",
                        column: x => x.BookCategoryId,
                        principalTable: "BookCategories",
                        principalColumn: "BookCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.BookId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName", "Biography", "DateOfBirth", "Nationality" },
                values: new object[,]
                {
                    { 1, "George Orwell", "George Orwell was an English novelist, essayist, journalist and critic.", new DateTime(1903, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "British" },
                    { 2, "J.K. Rowling", "J.K. Rowling is a British author, best known for writing the Harry Potter fantasy series.", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "British" },
                    { 3, "Ernest Hemingway", "Ernest Hemingway was an American novelist, short-story writer, and journalist.", new DateTime(1899, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "American" },
                    { 4, "Jane Austen", "Jane Austen was an English novelist known primarily for her six major novels.", new DateTime(1775, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "British" },
                    { 5, "Mark Twain", "Mark Twain was an American writer, humorist, entrepreneur, publisher, and lecturer.", new DateTime(1835, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "American" },
                    { 6, "Agatha Christie", "Agatha Christie was an English writer known for her sixty-six detective novels.", new DateTime(1890, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "British" },
                    { 7, "Gabriel Garcia Marquez", "Gabriel Garcia Marquez was a Colombian novelist, short-story writer, screenwriter, and journalist.", new DateTime(1927, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colombian" },
                    { 8, "Leo Tolstoy", "Leo Tolstoy was a Russian writer who is regarded as one of the greatest authors of all time.", new DateTime(1828, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russian" }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookCategoryId", "BookGenreType", "Description" },
                values: new object[,]
                {
                    { 1, "Fiction", "A genre of books that contains fictional stories." },
                    { 2, "Non-Fiction", "A genre of books that contains factual and real stories." },
                    { 3, "Mystery", "A genre of books that deals with the solution of a crime or the unraveling of secrets." },
                    { 4, "Fantasy", "A genre of books that contains magical or supernatural elements." },
                    { 5, "Science Fiction", "A genre of books that deals with imaginative and futuristic concepts." },
                    { 6, "Biography", "A genre of books that details the life of a real person." },
                    { 7, "Romance", "A genre of books that focuses on romantic relationships." },
                    { 8, "Horror", "A genre of books that is intended to scare or thrill the reader." }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "ContactName", "Country", "Email", "PhoneNumber", "PublisherName" },
                values: new object[,]
                {
                    { 1, "John Pearson", "USA", "contact@pearson.com", "123-456-7890", "Pearson" },
                    { 2, "Jane Random", "UK", "info@penguinrandomhouse.com", "987-654-3210", "Penguin Random House" },
                    { 3, "Alice Harper", "USA", "support@harpercollins.com", "555-123-4567", "HarperCollins" },
                    { 4, "Bob Simon", "USA", "service@simonandschuster.com", "555-987-6543", "Simon & Schuster" },
                    { 5, "Carol Macmillan", "UK", "help@macmillan.com", "555-654-3210", "Macmillan" },
                    { 6, "David Hachette", "France", "info@hachette.com", "555-321-9876", "Hachette Livre" },
                    { 7, "Eva Scholastic", "USA", "contact@scholastic.com", "555-789-1234", "Scholastic" },
                    { 8, "Frank Bloomsbury", "UK", "info@bloomsbury.com", "555-456-7890", "Bloomsbury" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleDescription", "RoleName" },
                values: new object[,]
                {
                    { 1, "Customer role", "User" },
                    { 2, "Author role", "Author" },
                    { 3, "Publisher role", "Publisher" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "BookCategoryId", "BookDescription", "BookName", "Price", "PublicationDate", "PublisherId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, "A dystopian social science fiction novel and cautionary tale, written by the English writer George Orwell.", "1984", 19.99m, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 100 },
                    { 2, 2, 4, "A fantasy novel written by British author J.K. Rowling. It is the first book in the Harry Potter series.", "Harry Potter and the Philosopher's Stone", 29.99m, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 200 },
                    { 3, 3, 1, "A short novel written by the American author Ernest Hemingway in 1951 in Cuba, and published in 1952.", "The Old Man and the Sea", 15.99m, new DateTime(1952, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 150 },
                    { 4, 4, 7, "A romantic novel of manners written by Jane Austen in 1813.", "Pride and Prejudice", 12.99m, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 120 },
                    { 5, 5, 1, "A novel written by Mark Twain about a young boy growing up along the Mississippi River.", "The Adventures of Tom Sawyer", 18.99m, new DateTime(1876, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 130 },
                    { 6, 6, 3, "A detective novel by British author Agatha Christie featuring the Belgian detective Hercule Poirot.", "Murder on the Orient Express", 22.99m, new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 140 },
                    { 7, 7, 1, "A landmark 1967 novel by Colombian author Gabriel Garcia Marquez that tells the multi-generational story of the Buendia family.", "One Hundred Years of Solitude", 25.99m, new DateTime(1967, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 160 },
                    { 8, 8, 1, "A novel by the Russian author Leo Tolstoy, published from 1865 to 1869.", "War and Peace", 30.99m, new DateTime(1869, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 170 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "Email", "FullName", "PasswordHash", "PhoneNumber", "RoleId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "doe@gmail.com", "John Doe", "123123", "123-456-7890", 3, 0 },
                    { 2, new DateTime(1990, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane@gmail.com", "Jane Smith", "123123", "987-654-3210", 1, 1 },
                    { 3, new DateTime(1988, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnson@example.com", "Alice Johnson", "123123", "555-123-4567", 1, 0 },
                    { 4, new DateTime(1975, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob@gmail.com", "Bob Brown", "123123", "555-987-6543", 3, 1 },
                    { 5, new DateTime(1995, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "white@example.com", "Carol White", "123123", "555-654-3210", 2, 0 },
                    { 6, new DateTime(1982, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "green@example.com", "David Green", "123", "555-321-9876", 2, 0 },
                    { 7, new DateTime(2000, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "black@example.com", "Eva Black", "123123", "555-789-1234", 1, 1 },
                    { 8, new DateTime(1998, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "blue@example.com", "Frank Blue", "123123", "555-456-7890", 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderDate", "OrderStatus", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 },
                    { 2, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 4, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4 },
                    { 5, new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5 },
                    { 6, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6 },
                    { 7, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7 },
                    { 8, new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "BookId", "OrderId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 2, 19.99m },
                    { 3, 1, 1, 15.99m },
                    { 2, 2, 1, 29.99m },
                    { 4, 3, 1, 12.99m },
                    { 5, 4, 3, 18.99m },
                    { 6, 5, 2, 22.99m },
                    { 7, 6, 1, 25.99m },
                    { 8, 7, 1, 30.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCategoryId",
                table: "Books",
                column: "BookCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_BookId",
                table: "OrderDetails",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCarts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
