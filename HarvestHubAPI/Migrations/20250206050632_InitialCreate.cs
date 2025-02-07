using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHubProjectAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    CropId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.CropId);
                });

            migrationBuilder.CreateTable(
                name: "FarmSites",
                columns: table => new
                {
                    FarmSiteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmSiteName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    DefaultPrimaryCropId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmSites", x => x.FarmSiteId);
                });

            migrationBuilder.CreateTable(
                name: "WorkTaskTypes",
                columns: table => new
                {
                    WorkTaskTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTaskTypes", x => x.WorkTaskTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "FarmFields",
                columns: table => new
                {
                    FarmFieldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmSiteId = table.Column<int>(type: "int", nullable: false),
                    FarmFieldName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FarmFieldCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RowWidth = table.Column<float>(type: "real", nullable: false),
                    FarmFieldRowDirection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FarmFieldColorHexCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmFields", x => x.FarmFieldId);
                    table.ForeignKey(
                        name: "FK_FarmFields_FarmSites_FarmSiteId",
                        column: x => x.FarmSiteId,
                        principalTable: "FarmSites",
                        principalColumn: "FarmSiteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCustomerUser = table.Column<bool>(type: "bit", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGivenName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserEmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    UserStatus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FarmSiteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_FarmSites_FarmSiteId",
                        column: x => x.FarmSiteId,
                        principalTable: "FarmSites",
                        principalColumn: "FarmSiteId");
                });

            migrationBuilder.CreateTable(
                name: "WorkTasks",
                columns: table => new
                {
                    WorkTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmFieldId = table.Column<int>(type: "int", nullable: false),
                    WorkTaskTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkTaskStatusCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CanceledDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsStarted = table.Column<bool>(type: "bit", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTasks", x => x.WorkTaskId);
                    table.ForeignKey(
                        name: "FK_WorkTasks_FarmFields_FarmFieldId",
                        column: x => x.FarmFieldId,
                        principalTable: "FarmFields",
                        principalColumn: "FarmFieldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkTasks_WorkTaskTypes_WorkTaskTypeCode",
                        column: x => x.WorkTaskTypeCode,
                        principalTable: "WorkTaskTypes",
                        principalColumn: "WorkTaskTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FarmFields_FarmSiteId",
                table: "FarmFields",
                column: "FarmSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FarmSiteId",
                table: "Users",
                column: "FarmSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTasks_FarmFieldId",
                table: "WorkTasks",
                column: "FarmFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTasks_WorkTaskTypeCode",
                table: "WorkTasks",
                column: "WorkTaskTypeCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkTasks");

            migrationBuilder.DropTable(
                name: "FarmFields");

            migrationBuilder.DropTable(
                name: "WorkTaskTypes");

            migrationBuilder.DropTable(
                name: "FarmSites");
        }
    }
}
