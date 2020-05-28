using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class correctinglastaccessfieldname : Migration
    {
        protected override void Up (MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "last_acess",
                table: "user");

            migrationBuilder.AddColumn<DateTime>(
                name: "last_access",
                table: "user",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down (MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "last_access",
                table: "user");

            migrationBuilder.AddColumn<DateTime>(
                name: "last_acess",
                table: "user",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
