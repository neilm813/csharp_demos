using Microsoft.EntityFrameworkCore.Migrations;

namespace TripPlanner.Migrations
{
    public partial class UpdateDestinationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationMedia_Users_UserId",
                table: "DestinationMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_TripDestinations_DestinationMedia_DestinationMediaId",
                table: "TripDestinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DestinationMedia",
                table: "DestinationMedia");

            migrationBuilder.RenameTable(
                name: "DestinationMedia",
                newName: "DestinationMedias");

            migrationBuilder.RenameIndex(
                name: "IX_DestinationMedia_UserId",
                table: "DestinationMedias",
                newName: "IX_DestinationMedias_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DestinationMedias",
                table: "DestinationMedias",
                column: "DestinationMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationMedias_Users_UserId",
                table: "DestinationMedias",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDestinations_DestinationMedias_DestinationMediaId",
                table: "TripDestinations",
                column: "DestinationMediaId",
                principalTable: "DestinationMedias",
                principalColumn: "DestinationMediaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationMedias_Users_UserId",
                table: "DestinationMedias");

            migrationBuilder.DropForeignKey(
                name: "FK_TripDestinations_DestinationMedias_DestinationMediaId",
                table: "TripDestinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DestinationMedias",
                table: "DestinationMedias");

            migrationBuilder.RenameTable(
                name: "DestinationMedias",
                newName: "DestinationMedia");

            migrationBuilder.RenameIndex(
                name: "IX_DestinationMedias_UserId",
                table: "DestinationMedia",
                newName: "IX_DestinationMedia_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DestinationMedia",
                table: "DestinationMedia",
                column: "DestinationMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationMedia_Users_UserId",
                table: "DestinationMedia",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDestinations_DestinationMedia_DestinationMediaId",
                table: "TripDestinations",
                column: "DestinationMediaId",
                principalTable: "DestinationMedia",
                principalColumn: "DestinationMediaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
