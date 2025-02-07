using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHubProjectAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTasks_WorkTaskTypes_WorkTaskTypeCode",
                table: "WorkTasks");

            migrationBuilder.DropIndex(
                name: "IX_WorkTasks_WorkTaskTypeCode",
                table: "WorkTasks");

            migrationBuilder.AddColumn<string>(
                name: "WorkTaskTypeCode1",
                table: "WorkTasks",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "FarmFieldColorHexCode",
                table: "FarmFields",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryCropId",
                table: "FarmFields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkTasks_WorkTaskTypeCode1",
                table: "WorkTasks",
                column: "WorkTaskTypeCode1");

            migrationBuilder.CreateIndex(
                name: "IX_FarmFields_PrimaryCropId",
                table: "FarmFields",
                column: "PrimaryCropId");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmFields_Crops_PrimaryCropId",
                table: "FarmFields",
                column: "PrimaryCropId",
                principalTable: "Crops",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTasks_WorkTaskTypes_WorkTaskTypeCode1",
                table: "WorkTasks",
                column: "WorkTaskTypeCode1",
                principalTable: "WorkTaskTypes",
                principalColumn: "WorkTaskTypeCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmFields_Crops_PrimaryCropId",
                table: "FarmFields");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTasks_WorkTaskTypes_WorkTaskTypeCode1",
                table: "WorkTasks");

            migrationBuilder.DropIndex(
                name: "IX_WorkTasks_WorkTaskTypeCode1",
                table: "WorkTasks");

            migrationBuilder.DropIndex(
                name: "IX_FarmFields_PrimaryCropId",
                table: "FarmFields");

            migrationBuilder.DropColumn(
                name: "WorkTaskTypeCode1",
                table: "WorkTasks");

            migrationBuilder.DropColumn(
                name: "PrimaryCropId",
                table: "FarmFields");

            migrationBuilder.AlterColumn<string>(
                name: "FarmFieldColorHexCode",
                table: "FarmFields",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "IX_WorkTasks_WorkTaskTypeCode",
                table: "WorkTasks",
                column: "WorkTaskTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTasks_WorkTaskTypes_WorkTaskTypeCode",
                table: "WorkTasks",
                column: "WorkTaskTypeCode",
                principalTable: "WorkTaskTypes",
                principalColumn: "WorkTaskTypeCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
