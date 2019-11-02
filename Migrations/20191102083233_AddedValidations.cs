using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStoreSample.Migrations
{
    public partial class AddedValidations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Genre",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Artist",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Album",
                newName: "IsActive");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genre",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Genre",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Artist",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Album",
                newName: "isActive");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genre",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
