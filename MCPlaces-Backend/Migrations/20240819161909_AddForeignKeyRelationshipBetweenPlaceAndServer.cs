using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCPlaces_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyRelationshipBetweenPlaceAndServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServerId",
                table: "Places",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Places_ServerId",
                table: "Places",
                column: "ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Servers_ServerId",
                table: "Places",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Servers_ServerId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_ServerId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "Places");
        }
    }
}
