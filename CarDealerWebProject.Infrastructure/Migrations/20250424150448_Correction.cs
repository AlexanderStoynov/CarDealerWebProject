using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealerWebProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "Vehicles",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Vehicle maker name",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Vehicle maker name");

            migrationBuilder.AlterColumn<int>(
                name: "EngineCapacity",
                table: "Vehicles",
                type: "int",
                nullable: true,
                comment: "Engine capacity",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Engine capacity");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Vehicles",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                comment: "Vehicle color",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Vehicle color");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Category identifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "If vehicle is sold");

            migrationBuilder.AddColumn<int>(
                name: "Motorcycle_EngineCapacity",
                table: "Vehicles",
                type: "int",
                nullable: true,
                comment: "Engine capacity");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                },
                comment: "Vehicle category");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CategoryId",
                table: "Vehicles",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Category_CategoryId",
                table: "Vehicles",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Category_CategoryId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CategoryId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Motorcycle_EngineCapacity",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "Vehicles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Vehicle maker name",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Vehicle maker name");

            migrationBuilder.AlterColumn<int>(
                name: "EngineCapacity",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Engine capacity",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Engine capacity");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Vehicle color",
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35,
                oldComment: "Vehicle color");
        }
    }
}
