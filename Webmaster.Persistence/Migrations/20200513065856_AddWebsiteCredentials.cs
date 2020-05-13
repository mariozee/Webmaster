using Microsoft.EntityFrameworkCore.Migrations;

namespace Webmaster.Persistence.Migrations
{
    public partial class AddWebsiteCredentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebsiteCredentials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    WebsiteId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteCredentials", x => new { x.Id, x.WebsiteId });
                    table.ForeignKey(
                        name: "FK_WebsiteCredentials_Website_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "Website",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteCredentials_WebsiteId",
                table: "WebsiteCredentials",
                column: "WebsiteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebsiteCredentials");
        }
    }
}
