using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPortal.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_AspNetUsers_ApplicationUserId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_ApplicationUserId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_courses_ApplicationUserId",
                table: "courses",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_AspNetUsers_ApplicationUserId",
                table: "courses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
