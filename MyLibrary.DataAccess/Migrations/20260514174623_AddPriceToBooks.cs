using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "Books",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Books",
                newName: "price");
        }
    }
}
