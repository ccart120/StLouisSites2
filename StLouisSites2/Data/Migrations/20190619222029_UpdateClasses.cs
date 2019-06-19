using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisSites2.Data.Migrations
{
    public partial class UpdateClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "LocationRatings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LocationRatings_LocationID",
                table: "LocationRatings",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationRatings_Locations_LocationID",
                table: "LocationRatings",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationRatings_Locations_LocationID",
                table: "LocationRatings");

            migrationBuilder.DropIndex(
                name: "IX_LocationRatings_LocationID",
                table: "LocationRatings");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "LocationRatings");
        }
    }
}
