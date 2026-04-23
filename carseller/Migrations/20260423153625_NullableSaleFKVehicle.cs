using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace carseller.Migrations
{
    /// <inheritdoc />
    public partial class NullableSaleFKVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Sale_SaleId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Sale_SaleId",
                table: "Vehicle",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Sale_SaleId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Sale_SaleId",
                table: "Vehicle",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
