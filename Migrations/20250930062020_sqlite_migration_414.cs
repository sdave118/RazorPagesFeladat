using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesFeladat.Migrations
{
    /// <inheritdoc />
    public partial class sqlite_migration_414 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarlangModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false),
                    Hossz = table.Column<int>(type: "INTEGER", nullable: false),
                    Kiterjedes = table.Column<int>(type: "INTEGER", nullable: false),
                    Melyseg = table.Column<int>(type: "INTEGER", nullable: false),
                    Magassag = table.Column<int>(type: "INTEGER", nullable: false),
                    Telepules = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarlangModels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarlangModels");
        }
    }
}
