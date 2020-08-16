using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrPizza.Domain.Infra.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sabor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saborId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    EmailLogin = table.Column<string>(type: "varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", nullable: false),
                    DDD = table.Column<string>(type: "varchar(2)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Endereco = table.Column<string>(type: "varchar(80)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(20)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecoId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: true),
                    IdEndereco = table.Column<Guid>(nullable: true),
                    DataHoraPedido = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidoId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PedidoId = table.Column<Guid>(nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzaId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizza_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PizzaSabor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPizza = table.Column<Guid>(nullable: false),
                    IdSabor = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzaSaborId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaSabor_Pizza_IdPizza",
                        column: x => x.IdPizza,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaSabor_Sabor_IdSabor",
                        column: x => x.IdSabor,
                        principalTable: "Sabor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sabor",
                columns: new[] { "Id", "Descricao", "Valor" },
                values: new object[,]
                {
                    { new Guid("afd43ced-bb64-4b2c-9b6d-358597484320"), "3 Queijos", 50m },
                    { new Guid("65f94207-10d6-4ffb-841d-8e8fda817555"), "Frango com requeijão ", 59.99m },
                    { new Guid("3de1e14e-4938-42ec-96b9-a4359f1ff072"), "Mussarela ", 42.5m },
                    { new Guid("bbb1d0c8-ee7c-4ef5-8d49-9a98293f5c9d"), "Calabresa ", 42.5m },
                    { new Guid("c06bfce9-12a9-45b1-9bf6-06a23a579c9d"), "Pepperoni", 55m },
                    { new Guid("06925036-bbec-4e46-b804-5137f3bc02d9"), "Portuguesa ", 45m },
                    { new Guid("11895cec-1106-400f-a1c6-d1077e21fb1e"), "Veggie ", 59.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdUsuario",
                table: "Endereco",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdUsuario",
                table: "Pedido",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_PedidoId",
                table: "Pizza",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaSabor_IdPizza",
                table: "PizzaSabor",
                column: "IdPizza");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaSabor_IdSabor",
                table: "PizzaSabor",
                column: "IdSabor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "PizzaSabor");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Sabor");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
