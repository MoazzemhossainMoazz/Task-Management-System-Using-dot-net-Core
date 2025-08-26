using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement1.Migrations
{
    /// <inheritdoc />
    public partial class picture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignTasks_Tasks_TaskModelsId",
                table: "AssignTasks");

            migrationBuilder.DropIndex(
                name: "IX_AssignTasks_TaskModelsId",
                table: "AssignTasks");

            migrationBuilder.DropColumn(
                name: "TaskModelsId",
                table: "AssignTasks");

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "TaskModelsId",
                table: "AssignTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AssignTasks_TaskModelsId",
                table: "AssignTasks",
                column: "TaskModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignTasks_Tasks_TaskModelsId",
                table: "AssignTasks",
                column: "TaskModelsId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
