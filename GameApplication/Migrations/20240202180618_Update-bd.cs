using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameApplication.Migrations
{
    public partial class Updatebd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SystemRequirements_GameId",
                table: "SystemRequirements");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRequirements_GameId",
                table: "SystemRequirements",
                column: "GameId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SystemRequirements_GameId",
                table: "SystemRequirements");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRequirements_GameId",
                table: "SystemRequirements",
                column: "GameId");
        }
    }
}
