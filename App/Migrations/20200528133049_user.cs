using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace App.Migrations {
    public partial class user : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable (
                name: "user",
                columns : table => new {
                    id = table.Column<int> (nullable: false)
                        .Annotation ("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                        username = table.Column<string> (nullable: true),
                        password = table.Column<string> (nullable: true),
                        last_acess = table.Column<DateTime> (nullable: false)
                },
                constraints : table => {
                    table.PrimaryKey ("pk_user", x => x.id);
                });
        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable (
                name: "user");
        }
    }
}