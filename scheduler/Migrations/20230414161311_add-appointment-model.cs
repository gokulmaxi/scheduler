using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scheduler.Migrations
{
    public partial class addappointmentmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApointmentModel",
                columns: table => new
                {
                    ApointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApointmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApointmentModel", x => x.ApointmentId);
                    table.ForeignKey(
                        name: "FK_ApointmentModel_AspNetUsers_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApointmentModel_UserIdId",
                table: "ApointmentModel",
                column: "UserIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApointmentModel");
        }
    }
}
