using Microsoft.EntityFrameworkCore.Migrations;

namespace Webmaster.Persistence.Migrations
{
    public partial class SeedCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WebsiteCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Arts and Entertainment" },
                    { 21, "Travel and Tourism" },
                    { 20, "Sports" },
                    { 19, "Science and Education" },
                    { 18, "Reference Materials" },
                    { 17, "Pets and Animals" },
                    { 16, "News and Media" },
                    { 15, "Lifestyle" },
                    { 14, "Law and Government" },
                    { 13, "Jobs and Career" },
                    { 22, "Vehicles" },
                    { 12, "Home and Garden" },
                    { 10, "Health" },
                    { 9, "Games" },
                    { 8, "Gambling" },
                    { 7, "Food and Drink" },
                    { 6, "Finance" },
                    { 5, "E commerce and Shopping" },
                    { 4, "Computers Electronics and Technology" },
                    { 3, "Community and Society" },
                    { 2, "Business and Consumer Services" },
                    { 11, "Hobbies and Leisure" },
                    { 23, "Adult" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "WebsiteCategory",
                keyColumn: "Id",
                keyValue: 23);
        }
    }
}
