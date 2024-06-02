using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateAttributeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutputTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    OneLine = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateAttributeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateAttributeEntity_TaskEntity_InputTaskId",
                        column: x => x.InputTaskId,
                        principalTable: "TaskEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TemplateAttributeEntity_TaskEntity_OutputTaskId",
                        column: x => x.OutputTaskId,
                        principalTable: "TaskEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TestCaseEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasAbsoluteScoring = table.Column<bool>(type: "bit", nullable: false),
                    TaskEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCaseEntity_TaskEntity_TaskEntityId",
                        column: x => x.TaskEntityId,
                        principalTable: "TaskEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TestCaseEntity_TaskEntity_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TaskEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolutionTestEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    CheckTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionTestEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolutionTestEntity_TaskEntity_TaskEntityId",
                        column: x => x.TaskEntityId,
                        principalTable: "TaskEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolutionTestEntity_TaskEntity_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TaskEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolutionTestEntity_UserEntity_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "UserEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolutionTestEntity_UserEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckAttributeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InputTestCaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutputTestCaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckAttributeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckAttributeEntity_TestCaseEntity_InputTestCaseId",
                        column: x => x.InputTestCaseId,
                        principalTable: "TestCaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CheckAttributeEntity_TestCaseEntity_OutputTestCaseId",
                        column: x => x.OutputTestCaseId,
                        principalTable: "TestCaseEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckAttributeEntity_InputTestCaseId",
                table: "CheckAttributeEntity",
                column: "InputTestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckAttributeEntity_OutputTestCaseId",
                table: "CheckAttributeEntity",
                column: "OutputTestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionTestEntity_TaskEntityId",
                table: "SolutionTestEntity",
                column: "TaskEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionTestEntity_TaskId",
                table: "SolutionTestEntity",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionTestEntity_UserEntityId",
                table: "SolutionTestEntity",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionTestEntity_UserId",
                table: "SolutionTestEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateAttributeEntity_InputTaskId",
                table: "TemplateAttributeEntity",
                column: "InputTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateAttributeEntity_OutputTaskId",
                table: "TemplateAttributeEntity",
                column: "OutputTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseEntity_TaskEntityId",
                table: "TestCaseEntity",
                column: "TaskEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseEntity_TaskId",
                table: "TestCaseEntity",
                column: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckAttributeEntity");

            migrationBuilder.DropTable(
                name: "SolutionTestEntity");

            migrationBuilder.DropTable(
                name: "TemplateAttributeEntity");

            migrationBuilder.DropTable(
                name: "TestCaseEntity");

            migrationBuilder.DropTable(
                name: "UserEntity");

            migrationBuilder.DropTable(
                name: "TaskEntity");
        }
    }
}
