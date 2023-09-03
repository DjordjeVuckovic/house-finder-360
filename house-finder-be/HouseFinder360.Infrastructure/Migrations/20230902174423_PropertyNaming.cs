using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseFinder360.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PropertyNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyPhoto_Properties_PropertyId",
                table: "PropertyPhoto");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "PropertyPhoto",
                newName: "RealEstateId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyPhoto_PropertyId",
                table: "PropertyPhoto",
                newName: "IX_PropertyPhoto_RealEstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyPhoto_Properties_RealEstateId",
                table: "PropertyPhoto",
                column: "RealEstateId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyPhoto_Properties_RealEstateId",
                table: "PropertyPhoto");

            migrationBuilder.RenameColumn(
                name: "RealEstateId",
                table: "PropertyPhoto",
                newName: "PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyPhoto_RealEstateId",
                table: "PropertyPhoto",
                newName: "IX_PropertyPhoto_PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyPhoto_Properties_PropertyId",
                table: "PropertyPhoto",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }
    }
}
