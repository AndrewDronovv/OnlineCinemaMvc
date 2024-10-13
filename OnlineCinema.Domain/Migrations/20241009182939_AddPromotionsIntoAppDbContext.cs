using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCinema.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddPromotionsIntoAppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Promocodes",
                table: "Promocodes");

            migrationBuilder.RenameTable(
                name: "Promocodes",
                newName: "Promotions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions");

            migrationBuilder.RenameTable(
                name: "Promotions",
                newName: "Promocodes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promocodes",
                table: "Promocodes",
                column: "Id");
        }
    }
}
