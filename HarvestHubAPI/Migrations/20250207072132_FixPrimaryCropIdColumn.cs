using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHubProjectAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixPrimaryCropIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                table: "FarmFields",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");


            migrationBuilder.CreateIndex(
                name: "IX_FarmFields_PrimaryCropId",
                table: "FarmFields",
                column: "PrimaryCropId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmFields_Crops_PrimaryCropId",
                table: "FarmFields");

            migrationBuilder.DropIndex(
                name: "IX_FarmFields_PrimaryCropId",
                table: "FarmFields");

            migrationBuilder.DropColumn(
                name: "PrimaryCropId",
                table: "FarmFields");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                table: "FarmFields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
