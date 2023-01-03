using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class mm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StId",
                table: "tbl_previouseExameDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_previouseExameDetails_StId",
                table: "tbl_previouseExameDetails",
                column: "StId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_previouseExameDetails_tbl_student_StId",
                table: "tbl_previouseExameDetails",
                column: "StId",
                principalTable: "tbl_student",
                principalColumn: "stu_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_previouseExameDetails_tbl_student_StId",
                table: "tbl_previouseExameDetails");

            migrationBuilder.DropIndex(
                name: "IX_tbl_previouseExameDetails_StId",
                table: "tbl_previouseExameDetails");

            migrationBuilder.DropColumn(
                name: "StId",
                table: "tbl_previouseExameDetails");
        }
    }
}
