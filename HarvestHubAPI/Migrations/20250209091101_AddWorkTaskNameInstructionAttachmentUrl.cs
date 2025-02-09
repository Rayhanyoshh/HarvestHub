using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHubProjectAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkTaskNameInstructionAttachmentUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                table: "WorkTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instruction",
                table: "WorkTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkTaskName",
                table: "WorkTasks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "WorkTasks");

            migrationBuilder.DropColumn(
                name: "Instruction",
                table: "WorkTasks");

            migrationBuilder.DropColumn(
                name: "WorkTaskName",
                table: "WorkTasks");
        }
    }
}
