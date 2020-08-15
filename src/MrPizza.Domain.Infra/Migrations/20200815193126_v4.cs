using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrPizza.Domain.Infra.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Usuarios_IdUsuario",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Pedidos_PedidoId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaSabor_Pizzas_IdPizza",
                table: "PizzaSabor");

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

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "Pizza");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "Pedido");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_PedidoId",
                table: "Pizza",
                newName: "IX_Pizza_PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedido",
                newName: "IX_Pedido_UsuarioId");

            migrationBuilder.InsertData(
                table: "Sabor",
                columns: new[] { "Id", "Descricao", "Valor" },
                values: new object[,]
                {
                    { new Guid("bd332ae9-affe-4f19-841e-c13cc45d6b30"), "3 Queijos", 50m },
                    { new Guid("97778198-5c3d-419c-844c-824991622c5f"), "Frango com requeijão ", 59.99m },
                    { new Guid("ea15ccfc-9fbe-41e6-874e-9a9ae6412cba"), "Mussarela ", 42.5m },
                    { new Guid("e6b5473e-3e91-4676-8840-f5bc95c58f95"), "Calabresa ", 42.5m },
                    { new Guid("f5b177f0-b823-430a-bc76-6150dbd2f6bb"), "Pepperoni", 55m },
                    { new Guid("f51d2342-79dd-4817-b637-1db10bc95b0a"), "Portuguesa ", 45m },
                    { new Guid("2915805c-dd98-4e97-b212-ee0132e6512f"), "Veggie ", 59.99m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Usuario_IdUsuario",
                table: "Endereco",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Usuario_UsuarioId",
                table: "Pedido",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Pedido_PedidoId",
                table: "Pizza",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaSabor_Pizza_IdPizza",
                table: "PizzaSabor",
                column: "IdPizza",
                principalTable: "Pizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Usuario_IdUsuario",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Usuario_UsuarioId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Pedido_PedidoId",
                table: "Pizza");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaSabor_Pizza_IdPizza",
                table: "PizzaSabor");

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("2915805c-dd98-4e97-b212-ee0132e6512f"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("97778198-5c3d-419c-844c-824991622c5f"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("bd332ae9-affe-4f19-841e-c13cc45d6b30"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("e6b5473e-3e91-4676-8840-f5bc95c58f95"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("ea15ccfc-9fbe-41e6-874e-9a9ae6412cba"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("f51d2342-79dd-4817-b637-1db10bc95b0a"));

            migrationBuilder.DeleteData(
                table: "Sabor",
                keyColumn: "Id",
                keyValue: new Guid("f5b177f0-b823-430a-bc76-6150dbd2f6bb"));

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Pizza",
                newName: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Pedido",
                newName: "Pedidos");

            migrationBuilder.RenameIndex(
                name: "IX_Pizza_PedidoId",
                table: "Pizzas",
                newName: "IX_Pizzas_PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_UsuarioId",
                table: "Pedidos",
                newName: "IX_Pedidos_UsuarioId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Usuarios_IdUsuario",
                table: "Endereco",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Pedidos_PedidoId",
                table: "Pizzas",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaSabor_Pizzas_IdPizza",
                table: "PizzaSabor",
                column: "IdPizza",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
