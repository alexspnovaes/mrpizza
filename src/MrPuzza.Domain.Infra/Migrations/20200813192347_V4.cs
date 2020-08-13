using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrPuzza.Domain.Infra.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPedido",
                table: "PizzaSabor");

            migrationBuilder.AddColumn<Guid>(
                name: "IdSabor",
                table: "PizzaSabor",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSabor",
                table: "PizzaSabor");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPedido",
                table: "PizzaSabor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
