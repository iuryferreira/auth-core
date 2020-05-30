using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class userunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "unique");

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_users_username",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "users",
                type: "unique",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
