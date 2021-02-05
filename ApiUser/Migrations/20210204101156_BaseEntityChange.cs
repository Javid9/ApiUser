using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiUser.Migrations
{
    public partial class BaseEntityChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Staus",
                table: "Users",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Users",
                newName: "Staus");
        }
    }
}
