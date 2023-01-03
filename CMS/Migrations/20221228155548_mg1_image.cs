using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class mg1_image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "depImage",
                table: "tbl_departement",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longDescription",
                table: "tbl_departement",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "shortDescription",
                table: "tbl_departement",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "depImage",
                table: "tbl_departement");

            migrationBuilder.DropColumn(
                name: "longDescription",
                table: "tbl_departement");

            migrationBuilder.DropColumn(
                name: "shortDescription",
                table: "tbl_departement");
        }
    }
}
