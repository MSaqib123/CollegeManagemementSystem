using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class mg5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "coImage",
                table: "tbl_Course",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coImage",
                table: "tbl_Course");
        }
    }
}
