using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrPizza.Domain.Infra.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Endereco_EnderecoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuarios");

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("404fa516-7ef4-4a38-b584-e62fd7542783"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("9e51543a-3e80-43b1-95ee-0223569a3f3d"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("a4e40d28-ed30-41c2-8321-cfec7fbb3b0b"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("bcf86e4d-9fd0-4713-9770-45645f3def0e"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("c913c12d-5728-4f52-a1b4-37e87d2c88bc"));

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Usuarios");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuario",
                table: "Endereco",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdUsuario",
                table: "Endereco",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Usuarios_IdUsuario",
                table: "Endereco",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Usuarios_IdUsuario",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_IdUsuario",
                table: "Endereco");

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
                name: "IdUsuario",
                table: "Endereco");

            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "Usuarios",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Sabor",
                columns: new[] { "Id", "Descricao", "Valor" },
                values: new object[,]
                {
                    { new Guid("404fa516-7ef4-4a38-b584-e62fd7542783"), "3 Queijos", 50m },
                    { new Guid("bcf86e4d-9fd0-4713-9770-45645f3def0e"), "Frango ", 59.99m },
                    { new Guid("9e51543a-3e80-43b1-95ee-0223569a3f3d"), "Requeijão ", 42.5m },
                    { new Guid("c913c12d-5728-4f52-a1b4-37e87d2c88bc"), "Mussarela ", 42.5m },
                    { new Guid("a4e40d28-ed30-41c2-8321-cfec7fbb3b0b"), "Calabresa ", 55m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Endereco_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
