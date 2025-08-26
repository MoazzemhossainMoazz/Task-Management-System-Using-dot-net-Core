using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement1.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignTasks_TaskInfoModels_TaskModelsId",
                table: "AssignTasks");

            migrationBuilder.DropTable(
                name: "TaskInfoModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignTasks_Tasks_TaskModelsId",
                table: "AssignTasks",
                column: "TaskModelsId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignTasks_Tasks_TaskModelsId",
                table: "AssignTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TaskInfoModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskInfoModels", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AssignTasks_TaskInfoModels_TaskModelsId",
                table: "AssignTasks",
                column: "TaskModelsId",
                principalTable: "TaskInfoModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
