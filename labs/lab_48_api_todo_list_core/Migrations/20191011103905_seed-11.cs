using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_48_api_todo_list_core.Migrations
{
    public partial class seed11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "TaskItemID",
                keyValue: 1,
                columns: new[] { "CategoryID", "UserID" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "TaskItemID",
                keyValue: 2,
                columns: new[] { "CategoryID", "UserID" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "TaskItemID",
                keyValue: 3,
                columns: new[] { "CategoryID", "UserID" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "TaskItemID",
                keyValue: 4,
                columns: new[] { "CategoryID", "UserID" },
                values: new object[] { 3, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "TaskItemID",
                keyValue: 1,
                columns: new[] { "CategoryID", "UserID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "TaskItemID",
                keyValue: 2,
                columns: new[] { "CategoryID", "UserID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "TaskItemID",
                keyValue: 3,
                columns: new[] { "CategoryID", "UserID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "TaskItemID",
                keyValue: 4,
                columns: new[] { "CategoryID", "UserID" },
                values: new object[] { null, null });
        }
    }
}
