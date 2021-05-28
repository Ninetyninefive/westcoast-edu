using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddedSchemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.EnsureSchema(
                name: "Courses");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User",
                newSchema: "Users");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course",
                newSchema: "Courses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "Users",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                schema: "Courses",
                table: "Course",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "Users",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                schema: "Courses",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "Users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Course",
                schema: "Courses",
                newName: "Courses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");
        }
    }
}
