using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreshMarket.Infrastructure.Migrations
{
    public partial class ChangeProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaisedIn",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Products",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "2473c530-d7c1-4b8a-871b-4a467a86992c", "AQAAAAEAACcQAAAAEPr1o9IYyTbdXKuYIhAVbkmXlgdH6oXGyM0OSSH2JkGIzb9beD2zDFlbc0EziqBiow==", "ff4184d9-5ae0-4ec5-93ab-a4eebbd2b6fa" });

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "87deca2e-5dbd-41bc-a6ce-b6132f6d25c2", "AQAAAAEAACcQAAAAECr/pF+dxk59We7EjH482m+MpymTeCfzIfvXnAqirgEo1czU4125y9idEmfWB+J7HQ==", "5e95e621-5f4e-4551-9ba8-c0bf5d51dabc" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "IsActive" },
                values: new object[] { "BG(near the border)", true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "IsActive" },
                values: new object[] { "Bulgaria (garden in Burgas)", true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "IsActive" },
                values: new object[] { "BG", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "RaisedIn",
                table: "Products",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8f0c65a-1b29-46fb-81fe-9db89e69d385", "AQAAAAEAACcQAAAAECmPI88S4WvS6rI7EjismagQC1PuLFXxte1N519b4yxFkcGUI69vPCfNQdC1Cs4PlQ==", "c2e5ded5-e3b8-4117-b48f-c7bdf58f38b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac8e0c81-2a7e-4a2b-b395-0840089069b8", "AQAAAAEAACcQAAAAED/rv9B7f1Nh6TBIsSAq558AIFUH8Fr6e4jhMtOvXEa/tjF7DnYjIdARKZbdu0RFzg==", "dcf21e63-945b-4e8a-a4af-0c3bfcf0bb2d" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "RaisedIn",
                value: "BG(near the border)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "RaisedIn",
                value: "Bulgaria (garden in Burgas)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "RaisedIn",
                value: "BG");
        }
    }
}
