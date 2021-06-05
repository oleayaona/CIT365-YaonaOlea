using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyScriptureJournal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scripture",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Book = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Chapter = table.Column<int>(type: "INTEGER", nullable: false),
                    Verse = table.Column<int>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripture", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scripture");
        }
    }
}
