using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpitiPVC.Migrations
{
    /// <inheritdoc />
    public partial class QuestionstableaddedcolumnAnsweredTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AnsweredTime",
                table: "Questions",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnsweredTime",
                table: "Questions");
        }
    }
}
