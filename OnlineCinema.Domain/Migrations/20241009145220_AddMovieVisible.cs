using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCinema.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieVisible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Movies");
        }
    }
}
