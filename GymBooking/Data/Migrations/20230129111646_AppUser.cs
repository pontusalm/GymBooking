using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class AppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GymClassId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GymClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserGymClass",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GymClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserGymClass", x => new { x.ApplicationUserId, x.GymClassId });
                    table.ForeignKey(
                        name: "FK_AppUserGymClass_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserGymClass_GymClasses_GymClassId",
                        column: x => x.GymClassId,
                        principalTable: "GymClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GymClassId",
                table: "AspNetUsers",
                column: "GymClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserGymClass_GymClassId",
                table: "AppUserGymClass",
                column: "GymClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_GymClasses_GymClassId",
                table: "AspNetUsers",
                column: "GymClassId",
                principalTable: "GymClasses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GymClasses_GymClassId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AppUserGymClass");

            migrationBuilder.DropTable(
                name: "GymClasses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GymClassId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GymClassId",
                table: "AspNetUsers");
        }
    }
}
