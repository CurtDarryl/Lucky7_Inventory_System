using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucky7_Inventory_System_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyForRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Role_StatusId",
                table: "Role",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Status_StatusId",
                table: "Role",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Status_StatusId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_StatusId",
                table: "Role");
        }
    }
}
