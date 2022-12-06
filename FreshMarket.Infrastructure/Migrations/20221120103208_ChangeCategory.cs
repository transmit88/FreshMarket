using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreshMarket.Infrastructure.Migrations
{
    public partial class ChangeCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "b8f0c65a-1b29-46fb-81fe-9db89e69d385", "AQAAAAEAACcQAAAAECmPI88S4WvS6rI7EjismagQC1PuLFXxte1N519b4yxFkcGUI69vPCfNQdC1Cs4PlQ==", "c2e5ded5-e3b8-4117-b48f-c7bdf58f38b2" });

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "ac8e0c81-2a7e-4a2b-b395-0840089069b8", "AQAAAAEAACcQAAAAED/rv9B7f1Nh6TBIsSAq558AIFUH8Fr6e4jhMtOvXEa/tjF7DnYjIdARKZbdu0RFzg==", "dcf21e63-945b-4e8a-a4af-0c3bfcf0bb2d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }
    }
}
