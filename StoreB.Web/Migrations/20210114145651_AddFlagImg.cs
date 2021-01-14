using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreB.Web.Migrations
{
    public partial class AddFlagImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlagImg",
                table: "Countries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlagImg",
                table: "Countries");
        }
    }
}
