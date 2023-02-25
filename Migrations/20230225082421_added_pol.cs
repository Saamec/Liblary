using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Liblary.Migrations
{
    /// <inheritdoc />
    public partial class added_pol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pol",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pol",
                table: "Users");
        }
    }
}
