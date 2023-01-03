using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class descript_course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "tbl_Course",
                maxLength: 25,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "tbl_Course");
        }
    }
}
