using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UlkelerDunyasi.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ulkeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulkeler", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ulkeler",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "Türkiye" },
                    { 2, "ABD" },
                    { 3, "Kanada" },
                    { 4, "Norveç" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ulkeler");
        }
    }
}
