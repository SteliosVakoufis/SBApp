using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmarks_Application.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookmarks",
                columns: table => new
                {
                    bookmark_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookmark_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookmark_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookmark_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmarks", x => x.bookmark_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookmarks");
        }
    }
}
