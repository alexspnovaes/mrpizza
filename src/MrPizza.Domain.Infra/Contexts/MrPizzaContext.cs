using Microsoft.EntityFrameworkCore;
using MrPizza.Domain.Entities;

namespace MrPizza.Domain.Infra.Contexts
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
            modelBuilder.Entity<PizzaSabor>().HasKey(ps => ps.Id).HasName("PK_pizzaSaborId");
            modelBuilder.Entity<PizzaSabor>()
                .HasOne(ps => ps.Pizza)
                .WithMany(p => p.PizzaSabores)
                .HasForeignKey(ps => ps.IdPizza);
            modelBuilder.Entity<PizzaSabor>()
                .HasOne(ps => ps.Sabor)
                .WithMany(p => p.PizzaSabores)
                .HasForeignKey(ps => ps.IdSabor);

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasMany(e => e.Pizzas)
                    .WithOne(e => e.Pedido);
                entity.HasKey(e => e.Id).HasName("PK_pedidoId");
                entity.Property(e => e.IdEndereco);
                entity.Property(e => e.IdUsuario);
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
                entity.Property(e => e.Valor).IsRequired().HasColumnType("decimal(8,2)");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_enderecoId");
                entity.Property(e => e.Bairro).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.Cep).IsRequired().HasColumnType("varchar(8)");
                entity.Property(e => e.Complemento).HasColumnType("varchar(20)");
                entity.Property(e => e.Cidade).IsRequired().HasColumnType("varchar(50)");
                entity.Property(e => e.Numero).IsRequired().HasColumnType("varchar(10)");
                entity.Property(e => e.Rua).HasColumnName("endereco").IsRequired().HasColumnType("varchar(80)");
                entity.Property(e => e.Estado).IsRequired().HasColumnType("varchar(2)");
            });

            modelBuilder.Entity<Sabor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_saborId");
                entity.Property(e => e.Descricao).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.Valor).IsRequired().HasColumnType("decimal(8,2)");
            });

            modelBuilder.Entity<Sabor>().HasData(
                new Sabor("3 Queijos", 50),
                new Sabor("Frango com requeijão ", (decimal)59.99),
                new Sabor("Mussarela ", (decimal)42.50),
                new Sabor("Calabresa ", (decimal)42.50),
                new Sabor("Pepperoni", 55),
                new Sabor("Portuguesa ", 45),
                new Sabor("Veggie ", (decimal)59.99));
        }
    }
}
