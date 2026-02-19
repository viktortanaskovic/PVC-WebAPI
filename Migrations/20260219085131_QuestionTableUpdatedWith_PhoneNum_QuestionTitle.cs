using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpitiPVC.Migrations
{
    /// <inheritdoc />
    public partial class QuestionTableUpdatedWith_PhoneNum_QuestionTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Questions",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuestionTitle",
                table: "Questions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionTitle",
                table: "Questions");
        }
    }
}
