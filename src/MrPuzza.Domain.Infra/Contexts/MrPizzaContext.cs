using Microsoft.EntityFrameworkCore;
using MrPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MrPuzza.Domain.Infra.Contexts
{
    public class MrPizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public MrPizzaContext(DbContextOptions<MrPizzaContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoPizza>().HasKey(pp => pp.Id).HasName("PK_pedidoPizzaId");
            modelBuilder.Entity<PedidoPizza>()
                .HasOne(pp => pp.Pizza)
                .WithMany(p => p.PedidosPizzas)
                .HasForeignKey(pp => pp.IdPizza);
            modelBuilder.Entity<PedidoPizza>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.PedidosPizzas)
                .HasForeignKey(pp => pp.IdPedido);


            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_pedidoId");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_usuarioId");
                entity.Property(e => e.Nome).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.DDD).IsRequired().HasColumnType("varchar(2)");
                entity.Property(e => e.EmailLogin).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.IdEndereco).IsRequired();
                entity.Property(e => e.Senha).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.Telefone).IsRequired().HasColumnType("varchar(9)");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_pizzaId");
                entity.Property(e => e.Nome).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.Descricao).IsRequired().HasColumnType("varchar(500)");
                entity.Property(e => e.Valor).IsRequired().HasColumnType("decimal(8,2)");
            });
        }
    }
}
