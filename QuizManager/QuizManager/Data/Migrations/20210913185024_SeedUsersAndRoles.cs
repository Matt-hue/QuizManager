using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizManager.Data.Migrations
{
    public partial class SeedUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "1c2e0f3a-3e1b-49e8-9c15-e081fd790813", "Restricted", "RESTRICTED" },
                    { "2", "c3e203de-4e96-46df-97ec-9df2ee8e681a", "View", "VIEW" },
                    { "3", "5486cdf1-5904-42a3-80f6-e54ccf3c3f7b", "Edit", "EDIT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3C2F4A0C-8B17-4B26-B061-48EFDAD23DCE", 0, "997e84aa-e307-4d9a-9126-dea82b9b342c", "view@quiz.com", true, false, null, "VIEW@QUIZ.COM", "VIEW@QUIZ.COM", "AQAAAAEAACcQAAAAEAkcZA80BvNb3m/otgWjyzYR8UeuRgmuRkcXlSoy9iFTNSBPs3vRl4dJXVJY2PlwDA==", null, false, "700a6258-16ee-4ef7-87a8-c0addba4d2a5", false, "view@quiz.com" },
                    { "A35C587A-F790-436B-B480-FBA89D0C1C13", 0, "0babc787-6ee8-4180-bc31-420d3cbfc1a9", "restricted@quiz.com", true, false, null, "RESTRICTED@QUIZ.COM", "RESTRICTED@QUIZ.COM", "AQAAAAEAACcQAAAAEDaXgG4jymZ2uiFfzWcRl5ozt0ouciuwKIvlEE6ZWG3SlxjQWYca0foOJnSV6LIp/A==", null, false, "c463b9e8-039f-43b7-868c-4a44215c4eea", false, "restricted@quiz.com" },
                    { "912620D3-0481-401C-8DB4-5E127DB0D4A7", 0, "4fa2efbc-e9d2-4aad-ab19-fe7af538ec29", "edit@quiz.com", true, false, null, "EDIT@QUIZ.COM", "EDIT@QUIZ.COM", "AQAAAAEAACcQAAAAEHzOmmJE3qZk4ynASCwrTV9xeOUs9ilnDG970NE8TNVHEpgOSxYjJAzHIeIFUY9z7A==", null, false, "9e9a0ed2-0f32-4309-944e-1a2841b498dd", false, "edit@quiz.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3C2F4A0C-8B17-4B26-B061-48EFDAD23DCE", "2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "A35C587A-F790-436B-B480-FBA89D0C1C13", "1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "912620D3-0481-401C-8DB4-5E127DB0D4A7", "3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3C2F4A0C-8B17-4B26-B061-48EFDAD23DCE", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "912620D3-0481-401C-8DB4-5E127DB0D4A7", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "A35C587A-F790-436B-B480-FBA89D0C1C13", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3C2F4A0C-8B17-4B26-B061-48EFDAD23DCE");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "912620D3-0481-401C-8DB4-5E127DB0D4A7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A35C587A-F790-436B-B480-FBA89D0C1C13");
        }
    }
}
