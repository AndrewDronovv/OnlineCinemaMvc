using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCinema.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Promotions");
        }
    }
}
