using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("8ef5d82a-1c69-4039-85d9-0ca6a1afa093"), null, "Personal activities", 50 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("a847fe4b-f504-4ce6-88b4-5a0e7d04259e"), null, "pending activities", 20 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "PriorityTask", "Title" },
                values: new object[] { new Guid("14af8dea-0be2-4bde-b673-ae6563db4823"), new Guid("8ef5d82a-1c69-4039-85d9-0ca6a1afa093"), new DateTime(2022, 9, 9, 22, 15, 0, 791, DateTimeKind.Local).AddTicks(7198), null, 0, "Finish watching movies on Netflix" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "PriorityTask", "Title" },
                values: new object[] { new Guid("4f97edb4-a1bb-4122-adbf-0393f2194e63"), new Guid("a847fe4b-f504-4ce6-88b4-5a0e7d04259e"), new DateTime(2022, 9, 9, 22, 15, 0, 791, DateTimeKind.Local).AddTicks(7188), null, 1, "Pay public services" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("14af8dea-0be2-4bde-b673-ae6563db4823"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4f97edb4-a1bb-4122-adbf-0393f2194e63"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("8ef5d82a-1c69-4039-85d9-0ca6a1afa093"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("a847fe4b-f504-4ce6-88b4-5a0e7d04259e"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
