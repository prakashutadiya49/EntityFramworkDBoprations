using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDBoprationAPI.Migrations
{
    /// <inheritdoc />
    public partial class sixaddnewtablemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "languagedatatransfertable",
                columns: table => new
                {
                    languageid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    languagename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languagedatatransfertable", x => x.languageid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "languagedatatransfertable");
        }
    }
}
