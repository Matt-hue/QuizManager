using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizManager.Data.Migrations
{
    public partial class QuizQuestionAnswerEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 600, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 1000, nullable: true),
                    QuizId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 1000, nullable: true),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1c2e0f3a-3e1b-49e8-9c15-e081fd790813");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c3e203de-4e96-46df-97ec-9df2ee8e681a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "5486cdf1-5904-42a3-80f6-e54ccf3c3f7b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3C2F4A0C-8B17-4B26-B061-48EFDAD23DCE",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "997e84aa-e307-4d9a-9126-dea82b9b342c", "700a6258-16ee-4ef7-87a8-c0addba4d2a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "912620D3-0481-401C-8DB4-5E127DB0D4A7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4fa2efbc-e9d2-4aad-ab19-fe7af538ec29", "9e9a0ed2-0f32-4309-944e-1a2841b498dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A35C587A-F790-436B-B480-FBA89D0C1C13",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0babc787-6ee8-4180-bc31-420d3cbfc1a9", "c463b9e8-039f-43b7-868c-4a44215c4eea" });
        }
    }
}
