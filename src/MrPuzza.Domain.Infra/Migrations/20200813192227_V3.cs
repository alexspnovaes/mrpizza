using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrPuzza.Domain.Infra.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Pizzas");

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
                name: "PizzaSabor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPizza = table.Column<Guid>(nullable: false),
                    IdPedido = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzaSaborId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaSabor_Pizzas_IdPizza",
                        column: x => x.IdPizza,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaSabor_Sabor_IdPizza",
                        column: x => x.IdPizza,
                        principalTable: "Sabor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaSabor_IdPizza",
                table: "PizzaSabor",
                column: "IdPizza");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaSabor");

            migrationBuilder.DropTable(
                name: "Sabor");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Pizzas",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Pizzas",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
