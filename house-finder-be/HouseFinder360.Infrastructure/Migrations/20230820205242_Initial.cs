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
                    StreetName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    StreetLongitude = table.Column<double>(type: "double precision", nullable: false),
                    StreetLatitude = table.Column<double>(type: "double precision", nullable: false),
                    CityName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CityLongitude = table.Column<double>(type: "double precision", nullable: false),
                    CityLatitude = table.Column<double>(type: "double precision", nullable: false),
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
                    FirstName = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    LastName = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    UserRole = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    NumberOfRooms = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    PropertyState = table.Column<string>(type: "text", nullable: true),
                    Area = table.Column<int>(type: "integer", nullable: false),
                    Floor = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TotalFloors = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Price_Currency = table.Column<string>(type: "text", nullable: false),
                    AdditionalInfo_YearOfBuild = table.Column<DateOnly>(type: "date", nullable: false),
                    AdditionalInfo_AvailableFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    AdditionalInfo_BalconyNumber = table.Column<int>(type: "integer", nullable: false),
                    AdditionalInfo_BathroomNumber = table.Column<int>(type: "integer", nullable: false),
                    AdditionalInfo_ToiletNumber = table.Column<int>(type: "integer", nullable: false),
                    AdditionalInfo_HaveKitchen = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalInfo_HaveStorage = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalInfo_HaveParking = table.Column<bool>(type: "boolean", nullable: false),
                    PropertyType_TypeOfProperty = table.Column<int>(type: "integer", nullable: false),
                    PropertyTypeDeclaration = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    RegisterStatus = table.Column<int>(type: "integer", nullable: false),
                    Heating = table.Column<string>(type: "text", nullable: true),
                    Purpose = table.Column<int>(type: "integer", nullable: false),
                    ElevatorsNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyPhoto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Container = table.Column<string>(type: "text", nullable: false),
                    PhotoName = table.Column<string>(type: "text", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyPhoto_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AddressId",
                table: "Properties",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyPhoto_PropertyId",
                table: "PropertyPhoto",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyPhoto");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
