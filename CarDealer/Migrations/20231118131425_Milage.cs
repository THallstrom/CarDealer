using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealer.Migrations
{
    /// <inheritdoc />
    public partial class Milage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConditionId",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Milage",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionGrade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_ConditionId",
                table: "Car",
                column: "ConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Condition_ConditionId",
                table: "Car",
                column: "ConditionId",
                principalTable: "Condition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Condition_ConditionId",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropIndex(
                name: "IX_Car_ConditionId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "ConditionId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Milage",
                table: "Car");
        }
    }
}
