using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealer.Migrations
{
    /// <inheritdoc />
    public partial class Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maker_CarModel_ModelId",
                table: "Maker");

            migrationBuilder.DropIndex(
                name: "IX_Maker_ModelId",
                table: "Maker");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Maker");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelId",
                table: "Car",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_CarModel_ModelId",
                table: "Car",
                column: "ModelId",
                principalTable: "CarModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_CarModel_ModelId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_ModelId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Car");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Maker",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Maker_ModelId",
                table: "Maker",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maker_CarModel_ModelId",
                table: "Maker",
                column: "ModelId",
                principalTable: "CarModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
