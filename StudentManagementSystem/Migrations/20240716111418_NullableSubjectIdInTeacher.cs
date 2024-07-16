using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystem.Migrations
{
    public partial class NullableSubjectIdInTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Teachers", // Replace with the actual table name
                type: "int",
                nullable: true,
                oldNullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            // Check if the index exists before attempting to create it
            if (!migrationBuilder.ActiveProvider.Equals("Microsoft.EntityFrameworkCore.SqlServer", StringComparison.OrdinalIgnoreCase) &&
                !migrationBuilder.ActiveProvider.Equals("Microsoft.EntityFrameworkCore.Sqlite", StringComparison.OrdinalIgnoreCase)) // Adjust this condition as per your provider
            {
                migrationBuilder.CreateIndex(
                    name: "IX_Teachers_SubjectId",
                    table: "Teachers",
                    column: "SubjectId");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            // Drop the index only if it was successfully created
            if (!migrationBuilder.ActiveProvider.Equals("Microsoft.EntityFrameworkCore.SqlServer", StringComparison.OrdinalIgnoreCase) &&
                !migrationBuilder.ActiveProvider.Equals("Microsoft.EntityFrameworkCore.Sqlite", StringComparison.OrdinalIgnoreCase)) // Adjust this condition as per your provider
            {
                migrationBuilder.DropIndex(
                    name: "IX_Teachers_SubjectId",
                    table: "Teachers");
            }

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Teachers",
                type: "int",
                nullable: false,
                oldNullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
