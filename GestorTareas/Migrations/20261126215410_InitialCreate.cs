using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestorTareas.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Materia = table.Column<string>(type: "TEXT", nullable: false),
                    FechaLimite = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Prioridad = table.Column<int>(type: "INTEGER", nullable: false),
                    Completada = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "Id", "Completada", "Descripcion", "FechaLimite", "Materia", "Prioridad", "Titulo" },
                values: new object[,]
                {
                    { 1, false, "Repasar los temas de las unidades 1 a 3", new DateTime(2026, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programación III", 2, "Estudiar para el parcial" },
                    { 2, false, "Subir el PDF a la plataforma", new DateTime(2026, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fundamentos de Electrónica", 1, "Entregar informe de laboratorio" },
                    { 3, true, null, new DateTime(2026, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inglés", 0, "Leer capítulo 4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");
        }
    }
}
