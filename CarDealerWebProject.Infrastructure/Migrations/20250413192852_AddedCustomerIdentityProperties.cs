using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealerWebProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCustomerIdentityProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateListed",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "BodyType",
                table: "Vehicles",
                type: "int",
                nullable: true,
                comment: "Motorcycle body type");

            migrationBuilder.AddColumn<int>(
                name: "Car_BodyType",
                table: "Vehicles",
                type: "int",
                nullable: true,
                comment: "The cars body type");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Vehicle color");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Vehicles",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Transmission",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Vehicle transmission");

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Seller id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Seller name"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Seller e-mail")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropColumn(
                name: "BodyType",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Car_BodyType",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Vehicles");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateListed",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date vehicle is listed");
        }
    }
}
