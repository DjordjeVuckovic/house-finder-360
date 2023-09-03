using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseFinder360.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexOnPropertyUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Properties_UserId",
                table: "Properties",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Properties_UserId",
                table: "Properties");
        }
    }
}
