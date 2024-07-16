using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystem.Migrations
{
    public partial class AddingTeacherEnrolledId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherEnrolledId",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Teachers_TeacherEnrolledId",
                table: "Teachers",
                column: "TeacherEnrolledId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Teachers_TeacherEnrolledId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherEnrolledId",
                table: "Teachers");
        }
    }
}
