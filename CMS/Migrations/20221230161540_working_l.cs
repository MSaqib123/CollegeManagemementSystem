using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class working_l : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "tbl_student",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_student_userId",
                table: "tbl_student",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_student_AspNetUsers_userId",
                table: "tbl_student",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_student_AspNetUsers_userId",
                table: "tbl_student");

            migrationBuilder.DropIndex(
                name: "IX_tbl_student_userId",
                table: "tbl_student");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "tbl_student");
        }
    }
}
