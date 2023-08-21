using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseFinder360.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoName",
                table: "PropertyPhoto",
                newName: "Uri");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PropertyPhoto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PropertyPhoto");

            migrationBuilder.RenameColumn(
                name: "Uri",
                table: "PropertyPhoto",
                newName: "PhotoName");
        }
    }
}
