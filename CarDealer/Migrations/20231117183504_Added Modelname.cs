using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealer.Migrations
{
    /// <inheritdoc />
    public partial class AddedModelname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maker_ModelEntity_ModelId",
                table: "Maker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelEntity",
                table: "ModelEntity");

            migrationBuilder.RenameTable(
                name: "ModelEntity",
                newName: "CarModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Maker_CarModel_ModelId",
                table: "Maker",
                column: "ModelId",
                principalTable: "CarModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maker_CarModel_ModelId",
                table: "Maker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel");

            migrationBuilder.RenameTable(
                name: "CarModel",
                newName: "ModelEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelEntity",
                table: "ModelEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Maker_ModelEntity_ModelId",
                table: "Maker",
                column: "ModelId",
                principalTable: "ModelEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
