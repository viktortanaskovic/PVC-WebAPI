using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpitiPVC.Migrations
{
    /// <inheritdoc />
    public partial class Ubacivanjeproveredalijeodgovorenonapitanje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnswered",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnswered",
                table: "Questions");
        }
    }
}
