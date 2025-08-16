using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduFitMart.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseRelationToEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentWorkout_Students_StudentId",
                table: "StudentWorkout");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentWorkout_Workouts_WorkoutId",
                table: "StudentWorkout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentWorkout",
                table: "StudentWorkout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "StudentWorkout",
                newName: "StudentWorkouts");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_StudentWorkout_WorkoutId",
                table: "StudentWorkouts",
                newName: "IX_StudentWorkouts_WorkoutId");

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "Course",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentWorkouts",
                table: "StudentWorkouts",
                columns: new[] { "StudentId", "WorkoutId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Course_CourseId",
                table: "Enrollments",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentWorkouts_Students_StudentId",
                table: "StudentWorkouts",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentWorkouts_Workouts_WorkoutId",
                table: "StudentWorkouts",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "WorkoutId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Course_CourseId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentWorkouts_Students_StudentId",
                table: "StudentWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentWorkouts_Workouts_WorkoutId",
                table: "StudentWorkouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentWorkouts",
                table: "StudentWorkouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "StudentWorkouts",
                newName: "StudentWorkout");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentWorkouts_WorkoutId",
                table: "StudentWorkout",
                newName: "IX_StudentWorkout_WorkoutId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentWorkout",
                table: "StudentWorkout",
                columns: new[] { "StudentId", "WorkoutId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentWorkout_Students_StudentId",
                table: "StudentWorkout",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentWorkout_Workouts_WorkoutId",
                table: "StudentWorkout",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "WorkoutId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
