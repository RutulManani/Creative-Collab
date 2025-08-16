using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduFitMart.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixCoursePluralName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credits",
                table: "Course");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
