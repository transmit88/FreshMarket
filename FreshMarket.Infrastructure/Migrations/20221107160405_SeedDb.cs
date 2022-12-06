using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreshMarket.Infrastructure.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Creators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creators_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RaisedIn = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Creators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "bf33500b-be91-49db-ac1d-22f5582b34d9", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEExldw+SHyB1BTWguKITmU0rJtguaMxlfx7knr0rDoslSNsgEquXW0jxbR4mbnthBA==", null, false, "7e20078a-0cd5-4781-a61d-c16b63f9ba8a", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "128b39ce-1a22-40c3-89f4-ea2e293502da", "agent@mail.com", false, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAEJYADf6T0LNlkcDJT4s/bzw+RDyjtfI04LAJSv3cFNKVYl3VJDlTXc3CQGnxpzV1Bg==", null, false, "175cc681-1ac3-4618-b4e5-c33db54b1466", false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "fruits" },
                    { 2, "vegetable" },
                    { 3, "fruit import" },
                    { 4, "leafy vegetables" },
                    { 5, "others" }
                });

            migrationBuilder.InsertData(
                table: "Creators",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatorId", "Description", "ImageUrl", "Price", "RaisedIn", "Title" },
                values: new object[] { 1, "dea12856-c198-4129-b3f3-b893d8395082", 2, 1, "Sweet Tomate", "https://thumbs.dreamstime.com/b/big-boy-4412597.jpg", 3.20m, "BG(near the border)", "Tomate" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatorId", "Description", "ImageUrl", "Price", "RaisedIn", "Title" },
                values: new object[] { 2, "dea12856-c198-4129-b3f3-b893d8395082", 2, 1, "Fresh Cocumber for your salad", "https://www.tasteofhome.com/wp-content/uploads/2018/06/shutterstock_1058462660.jpg?fit=700,700", 2.20m, "Bulgaria (garden in Burgas)", "Cocumber" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatorId", "Description", "ImageUrl", "Price", "RaisedIn", "Title" },
                values: new object[] { 3, "dea12856-c198-4129-b3f3-b893d8395082", 1, 1, "The Green apple's white flesh is hard, crispy, and juicy.", "https://i.pinimg.com/originals/8f/16/71/8f16713bc593575ad152ac7f2fcd3e44.jpg", 1.30m, "BG", "Green Apple" });

            migrationBuilder.CreateIndex(
                name: "IX_Creators_UserId",
                table: "Creators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BuyerId",
                table: "Products",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatorId",
                table: "Products",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Creators");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
