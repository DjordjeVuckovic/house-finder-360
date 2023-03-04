using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HouseFinder360.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "text", nullable: false),
                    StreetNumber = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    NumberOfRooms = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    PropertyState = table.Column<int>(type: "integer", nullable: false),
                    Area_SquadMeter = table.Column<int>(type: "integer", nullable: false),
                    FloorInformation_Floor = table.Column<string>(type: "text", nullable: false),
                    FloorInformation_TotalFloors = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Price_Currency = table.Column<string>(type: "text", nullable: false),
                    PropertyType_TypeOfProperty = table.Column<int>(type: "integer", nullable: false),
                    PropertyType_PropertyTypeDeclaration = table.Column<string>(type: "text", nullable: false),
                    RegisterStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleProperty_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyAdditionalInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    YearOfBuild = table.Column<DateOnly>(type: "date", nullable: false),
                    AvailableFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    BalconyNumber = table.Column<int>(type: "integer", nullable: false),
                    BathroomNumber = table.Column<int>(type: "integer", nullable: false),
                    ToiletNumber = table.Column<int>(type: "integer", nullable: false),
                    HaveKitchen = table.Column<bool>(type: "boolean", nullable: false),
                    HaveStorage = table.Column<bool>(type: "boolean", nullable: false),
                    HaveParking = table.Column<bool>(type: "boolean", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAdditionalInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyAdditionalInfo_SaleProperty_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "SaleProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdditionalInfo_PropertyId",
                table: "PropertyAdditionalInfo",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleProperty_AddressId",
                table: "SaleProperty",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyAdditionalInfo");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SaleProperty");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
