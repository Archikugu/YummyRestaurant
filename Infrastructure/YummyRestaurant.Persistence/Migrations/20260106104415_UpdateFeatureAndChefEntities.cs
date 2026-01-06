using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyRestaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFeatureAndChefEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Chefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Chefs");
        }
    }
}
