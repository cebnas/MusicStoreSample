using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStoreSample.Migrations
{
    public partial class AddedActiveStatusToAlbumAndGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Genre",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Album",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Album");
        }
    }
}
