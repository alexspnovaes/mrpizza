using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrPizza.Domain.Infra.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("2fa0b740-14e0-4835-a4a1-192b085bbc8b"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("8be7a499-3804-4d03-8012-5da4f3c6fdee"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("a568bf5f-3761-4825-9d5c-f337f337755c"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("b13926e4-0205-4c48-bc71-3c2e7a08d203"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("b16693c9-ec4b-470a-a27d-2fe17662d555"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("d128e8c5-fbae-4f08-971a-3f665b4cc535"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("d4e50a26-c51d-4479-bc24-890645106050"));

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Usuarios");

            migrationBuilder.InsertData(
                table: "Sabor",
                columns: new[] { "Id", "Descricao", "Valor" },
                values: new object[,]
                {
                    { new Guid("62aeb419-4f3a-4e20-8a2a-dacc930d229b"), "3 Queijos", 50m },
                    { new Guid("837d08ee-32a6-48bf-9c75-ac0da4ceacde"), "Frango com requeijão ", 59.99m },
                    { new Guid("6a1d2b99-58d3-4397-9a18-2e3a2dca37d6"), "Mussarela ", 42.5m },
                    { new Guid("f11009b9-a501-4469-b72a-ba88b1c8e264"), "Calabresa ", 42.5m },
                    { new Guid("89af4cc9-dcf4-431c-9943-998f056cacf4"), "Pepperoni", 55m },
                    { new Guid("19bce1a6-4830-4d9d-b24c-6aaa7be83f85"), "Portuguesa ", 45m },
                    { new Guid("3231493d-51be-4b95-b94d-de454b2d1d63"), "Veggie ", 59.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("19bce1a6-4830-4d9d-b24c-6aaa7be83f85"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("3231493d-51be-4b95-b94d-de454b2d1d63"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("62aeb419-4f3a-4e20-8a2a-dacc930d229b"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("6a1d2b99-58d3-4397-9a18-2e3a2dca37d6"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("837d08ee-32a6-48bf-9c75-ac0da4ceacde"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("89af4cc9-dcf4-431c-9943-998f056cacf4"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("f11009b9-a501-4469-b72a-ba88b1c8e264"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdEndereco",
                table: "Usuarios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Sabor",
                columns: new[] { "Id", "Descricao", "Valor" },
                values: new object[,]
                {
                    { new Guid("8be7a499-3804-4d03-8012-5da4f3c6fdee"), "3 Queijos", 50m },
                    { new Guid("2fa0b740-14e0-4835-a4a1-192b085bbc8b"), "Frango com requeijão ", 59.99m },
                    { new Guid("d128e8c5-fbae-4f08-971a-3f665b4cc535"), "Mussarela ", 42.5m },
                    { new Guid("b16693c9-ec4b-470a-a27d-2fe17662d555"), "Calabresa ", 42.5m },
                    { new Guid("a568bf5f-3761-4825-9d5c-f337f337755c"), "Pepperoni", 55m },
                    { new Guid("b13926e4-0205-4c48-bc71-3c2e7a08d203"), "Portuguesa ", 45m },
                    { new Guid("d4e50a26-c51d-4479-bc24-890645106050"), "Veggie ", 59.99m }
                });
        }
    }
}
