using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreshMarket.Infrastructure.Migrations
{
    public partial class TestSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_BuyerId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef356580-1e8d-4376-8668-e251ecd353c9", "AQAAAAEAACcQAAAAEGA73apG+4iaF3wxQhKRev6A4XfQ8yKFrtssSHtz2WHtrnAcdtN1aeuJ5RAWsBjzWw==", "6c4b9be4-e567-48af-bb69-b9376f2bffac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7455c399-935a-4275-ae16-f57c5c7f9b88", "AQAAAAEAACcQAAAAEDUbLMCzKYoBV6ehDWxyv2jw5w0ktc9PhaiY55vt+6z+br2iuduoaoXhamSRyEbecw==", "38aff8a6-62f0-40b8-9ea7-1efc5fc5d1e5" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "BuyerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "BuyerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "BuyerId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_BuyerId",
                table: "Products",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_BuyerId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf33500b-be91-49db-ac1d-22f5582b34d9", "AQAAAAEAACcQAAAAEExldw+SHyB1BTWguKITmU0rJtguaMxlfx7knr0rDoslSNsgEquXW0jxbR4mbnthBA==", "7e20078a-0cd5-4781-a61d-c16b63f9ba8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "128b39ce-1a22-40c3-89f4-ea2e293502da", "AQAAAAEAACcQAAAAEJYADf6T0LNlkcDJT4s/bzw+RDyjtfI04LAJSv3cFNKVYl3VJDlTXc3CQGnxpzV1Bg==", "175cc681-1ac3-4618-b4e5-c33db54b1466" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "BuyerId",
                value: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "BuyerId",
                value: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "BuyerId",
                value: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_BuyerId",
                table: "Products",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
