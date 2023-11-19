using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealer.Migrations
{
    /// <inheritdoc />
    public partial class AddedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Maker_MakerID",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "GearBox",
                newName: "GearboxType");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Fuel",
                newName: "FuelType");

            migrationBuilder.RenameColumn(
                name: "MakerID",
                table: "Car",
                newName: "MakerId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_MakerID",
                table: "Car",
                newName: "IX_Car_MakerId");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Maker",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ModelEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maker_ModelId",
                table: "Maker",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Maker_MakerId",
                table: "Car",
                column: "MakerId",
                principalTable: "Maker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maker_ModelEntity_ModelId",
                table: "Maker",
                column: "ModelId",
                principalTable: "ModelEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Maker_MakerId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Maker_ModelEntity_ModelId",
                table: "Maker");

            migrationBuilder.DropTable(
                name: "ModelEntity");

            migrationBuilder.DropIndex(
                name: "IX_Maker_ModelId",
                table: "Maker");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Maker");

            migrationBuilder.RenameColumn(
                name: "GearboxType",
                table: "GearBox",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FuelType",
                table: "Fuel",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MakerId",
                table: "Car",
                newName: "MakerID");

            migrationBuilder.RenameIndex(
                name: "IX_Car_MakerId",
                table: "Car",
                newName: "IX_Car_MakerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Maker_MakerID",
                table: "Car",
                column: "MakerID",
                principalTable: "Maker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
