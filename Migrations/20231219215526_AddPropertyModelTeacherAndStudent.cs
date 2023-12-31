using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escuela.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyModelTeacherAndStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Teacher",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Teacher",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Student");
        }
    }
}
