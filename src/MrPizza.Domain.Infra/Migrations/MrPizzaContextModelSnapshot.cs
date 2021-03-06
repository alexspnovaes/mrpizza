﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MrPizza.Domain.Infra.Contexts;

namespace MrPizza.Domain.Infra.Migrations
{
    [DbContext(typeof(MrPizzaContext))]
    partial class MrPizzaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MrPizza.Domain.Entities.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnName("Endereco")
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id")
                        .HasName("PK_enderecoId");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("MrPizza.Domain.Entities.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHoraPedido")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IdEndereco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_pedidoId");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("MrPizza.Domain.Entities.Pizza", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id")
                        .HasName("PK_pizzaId");

                    b.HasIndex("PedidoId");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("MrPizza.Domain.Entities.PizzaSabor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPizza")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSabor")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_pizzaSaborId");

                    b.HasIndex("IdPizza");

                    b.HasIndex("IdSabor");

                    b.ToTable("PizzaSabor");
                });

            modelBuilder.Entity("MrPizza.Domain.Entities.Sabor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id")
                        .HasName("PK_saborId");

                    b.ToTable("Sabor");

                    b.HasData(
                        new
                        {
                            Id = new Guid("afd43ced-bb64-4b2c-9b6d-358597484320"),
                            Descricao = "3 Queijos",
                            Valor = 50m
                        },
                        new
                        {
                            Id = new Guid("65f94207-10d6-4ffb-841d-8e8fda817555"),
                            Descricao = "Frango com requeijão ",
                            Valor = 59.99m
                        },
                        new
                        {
                            Id = new Guid("3de1e14e-4938-42ec-96b9-a4359f1ff072"),
                            Descricao = "Mussarela ",
                            Valor = 42.5m
                        },
                        new
                        {
                            Id = new Guid("bbb1d0c8-ee7c-4ef5-8d49-9a98293f5c9d"),
                            Descricao = "Calabresa ",
                            Valor = 42.5m
                        },
                        new
                        {
                            Id = new Guid("c06bfce9-12a9-45b1-9bf6-06a23a579c9d"),
                            Descricao = "Pepperoni",
                            Valor = 55m
                        },
                        new
                        {
                            Id = new Guid("06925036-bbec-4e46-b804-5137f3bc02d9"),
                            Descricao = "Portuguesa ",
                            Valor = 45m
                        },
                        new
                        {
                            Id = new Guid("11895cec-1106-400f-a1c6-d1077e21fb1e"),
                            Descricao = "Veggie ",
                            Valor = 59.99m
                        });
                });

            modelBuilder.Entity("MrPizza.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("EmailLogin")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(9)");

                    b.HasKey("Id")
                        .HasName("PK_usuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("MrPizza.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("MrPizza.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Enderecos")
                        .HasForeignKey("IdUsuario");
                });

            modelBuilder.Entity("MrPizza.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("MrPizza.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdUsuario");
                });

            modelBuilder.Entity("MrPizza.Domain.Entities.Pizza", b =>
                {
                    b.HasOne("MrPizza.Domain.Entities.Pedido", "Pedido")
                        .WithMany("Pizzas")
                        .HasForeignKey("PedidoId");
                });

            modelBuilder.Entity("MrPizza.Domain.Entities.PizzaSabor", b =>
                {
                    b.HasOne("MrPizza.Domain.Entities.Pizza", "Pizza")
                        .WithMany("PizzaSabores")
                        .HasForeignKey("IdPizza")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MrPizza.Domain.Entities.Sabor", "Sabor")
                        .WithMany("PizzaSabores")
                        .HasForeignKey("IdSabor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
