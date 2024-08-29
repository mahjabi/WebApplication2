using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class des : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "subscribed",
                table: "Students",
                newName: "Subscribed");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Students",
                newName: "Phone");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Students",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Visiting_Hour",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Visiting_Hour",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Subscribed",
                table: "Students",
                newName: "subscribed");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Students",
                newName: "phone");
        }
    }
}
