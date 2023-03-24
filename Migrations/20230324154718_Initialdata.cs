using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyef.Migrations
{
    public partial class Initialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Desc", "Nombre", "Peso" },
                values: new object[] { new Guid("71c87875-4439-4d7c-ba96-f8ba9136db02"), null, "Personales", 20 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Desc", "Nombre", "Peso" },
                values: new object[] { new Guid("71c87875-4439-4d7c-ba96-f8ba9136dbaa"), null, "Pendientes", 20 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Desc", "FechaCreado", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("71c87875-4439-4d7c-ba96-f8ba9136db03"), new Guid("71c87875-4439-4d7c-ba96-f8ba9136db02"), "tarea 1", new DateTime(2023, 3, 24, 10, 47, 18, 414, DateTimeKind.Local).AddTicks(2866), 1, "Ejercicio" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Desc", "FechaCreado", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("71c87875-4439-4d7c-ba96-f8ba9136db04"), new Guid("71c87875-4439-4d7c-ba96-f8ba9136dbaa"), "tarea 2", new DateTime(2023, 3, 24, 10, 47, 18, 414, DateTimeKind.Local).AddTicks(2881), 0, "Supermercado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("71c87875-4439-4d7c-ba96-f8ba9136db03"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("71c87875-4439-4d7c-ba96-f8ba9136db04"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("71c87875-4439-4d7c-ba96-f8ba9136db02"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("71c87875-4439-4d7c-ba96-f8ba9136dbaa"));

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
