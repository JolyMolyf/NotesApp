using Microsoft.EntityFrameworkCore.Migrations;

namespace AinolWebApiCore.Migrations
{
    public partial class NoteChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Notes",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Notes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
