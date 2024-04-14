using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingChallengeMM.Server.Migrations
{
    /// <inheritdoc />
    public partial class updateTableFinancesAddedProductType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Finance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Finance");
        }
    }
}
