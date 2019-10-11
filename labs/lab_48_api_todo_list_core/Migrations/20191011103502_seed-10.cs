using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_48_api_todo_list_core.Migrations
{
    public partial class seed10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: false),
                    TaskItemID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    TaskItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: false),
                    TaskDone = table.Column<bool>(nullable: false),
                    DateDue = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    UserID1 = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.TaskItemID);
                    table.ForeignKey(
                        name: "FK_TaskItems_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskItems_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[] { 1, "Cat Name Here", "Description Here" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[] { 2, "Cat Name Here", "Description Here" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[] { 3, "Cat Name Here", "Description Here" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[] { 4, "Cat Name Here", "Description Here" });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemID", "CategoryID", "DateDue", "Description", "TaskDone", "UserID", "UserID1" },
                values: new object[] { 1, null, new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description Here", true, null, null });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemID", "CategoryID", "DateDue", "Description", "TaskDone", "UserID", "UserID1" },
                values: new object[] { 2, null, new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description Here", true, null, null });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemID", "CategoryID", "DateDue", "Description", "TaskDone", "UserID", "UserID1" },
                values: new object[] { 3, null, new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description Here", true, null, null });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemID", "CategoryID", "DateDue", "Description", "TaskDone", "UserID", "UserID1" },
                values: new object[] { 4, null, new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description Here", true, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "TaskItemID", "Username" },
                values: new object[] { 1, null, "User's name here" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "TaskItemID", "Username" },
                values: new object[] { 2, null, "User's name here" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "TaskItemID", "Username" },
                values: new object[] { 3, null, "User's name here" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "TaskItemID", "Username" },
                values: new object[] { 4, null, "User's name here" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_CategoryID",
                table: "TaskItems",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_UserID1",
                table: "TaskItems",
                column: "UserID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
