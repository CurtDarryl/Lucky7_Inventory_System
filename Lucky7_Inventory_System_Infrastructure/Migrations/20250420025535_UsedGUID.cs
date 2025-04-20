using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucky7_Inventory_System_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UsedGUID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key constraint before dropping the Id column
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            // Drop the existing Id column (which has the identity)
            migrationBuilder.DropColumn(
                name: "Id",
                table: "User");

            // Recreate the Id column with a string type (nvarchar(450))
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "User",
                type: "nvarchar(450)",  // Or whatever length you need
                nullable: false);

            // Re-add the primary key constraint to the new Id column
            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key constraint for the new Id column
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            // Drop the new Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "User");

            // Recreate the Id column as int with identity
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "User",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            // Re-add the primary key constraint to the original Id column
            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");
        }
    }
}
