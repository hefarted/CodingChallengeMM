using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingChallengeMM.Server.Migrations
{
    /// <inheritdoc />
    public partial class updateTableFinances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RepaymentFrequency",
                table: "Finance",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RepaymentFrequency",
                table: "Finance",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
