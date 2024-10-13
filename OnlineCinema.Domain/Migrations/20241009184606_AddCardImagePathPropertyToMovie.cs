using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCinema.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddCardImagePathPropertyToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardImagePath",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardImagePath",
                table: "Movies");
        }
    }
}
