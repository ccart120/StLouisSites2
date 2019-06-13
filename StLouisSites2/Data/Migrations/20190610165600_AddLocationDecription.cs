using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisSites2.Data.Migrations
{
    public partial class AddLocationDecription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Locations",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Locations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Locations",
                newName: "Id");
        }
    }
}
