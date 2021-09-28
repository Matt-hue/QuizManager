using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizManager.Data.Migrations
{
    public partial class QuestionOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Questions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "25ae4dc6-d9e6-47e9-aa35-e67ac041cd6d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "82a64525-0f3e-4a0d-a559-0add74700c4f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "206a4c30-16c7-4450-b54c-a23621b865d8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3C2F4A0C-8B17-4B26-B061-48EFDAD23DCE",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a2ca70d5-df0d-4d81-bb20-0aa9c8c10e56", "517f4ffe-4748-4e4e-ac3b-10822b1bfd7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "912620D3-0481-401C-8DB4-5E127DB0D4A7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "da484a38-b919-4b38-991a-2a6dd8fdc79e", "7b56ce7f-8bf7-495d-be5c-2672aba0990a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A35C587A-F790-436B-B480-FBA89D0C1C13",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7aa69d67-f3f9-4e3e-b3b5-7fc5824848b2", "e19f74ac-7420-4551-8647-52ed07b5ef88" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Questions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b0733132-6eb2-4fa7-adf9-7cfb79bf74c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "49d0a5ea-36aa-4061-97b9-5cd3ac47acce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "311e98ce-f998-4e2f-a751-8a4805a8db6b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3C2F4A0C-8B17-4B26-B061-48EFDAD23DCE",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8fcc5cf5-7329-4b9d-9200-f0eb6b44f49a", "9bee95a5-fb51-4356-bade-00bfa6e35238" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "912620D3-0481-401C-8DB4-5E127DB0D4A7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ab875d46-d6e6-480f-98a2-6784d5e39a44", "113d75a4-4689-4bab-b726-531f44393213" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A35C587A-F790-436B-B480-FBA89D0C1C13",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "04fc5ccb-abc5-428e-86e1-e767ca91b3fc", "4e91d817-bc72-4835-bff8-842d0c930583" });
        }
    }
}
