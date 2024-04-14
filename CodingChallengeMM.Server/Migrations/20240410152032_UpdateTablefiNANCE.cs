using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingChallengeMM.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablefiNANCE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Finance");

            migrationBuilder.DropColumn(
                name: "TermInMonths",
                table: "Finance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Finance",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TermInMonths",
                table: "Finance",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
