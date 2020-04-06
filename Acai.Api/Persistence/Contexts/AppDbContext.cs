using Microsoft.EntityFrameworkCore;
using  Acai.Api.Domain.Models;

namespace  Acai.Api.Persistence.Contexts
{
    //Classe resposável por mapear os models do dominio para tabelas
    public class AppDbContext : DbContext
    {       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<Pedido> Pedidos {get; set;}
        public DbSet<Tamanho> Tamanhos {get; set;}
        public DbSet<Sabor> Sabores {get; set;}
        public DbSet<Adicional> Adicionals {get; set;}
        public DbSet<PedidoAdicional> PedidosAdicionais {get; set;}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            ModelBuilderPedido(builder);
            ModelBuilderTamanho(builder);
            ModelBuilderSabor(builder);
            ModelBuilderAdicional(builder);
            ModelBuilderPedidoAdicional(builder);
        }

        private void ModelBuilderPedido(ModelBuilder builder){
            builder.Entity<Pedido>().ToTable("Pedido");
            builder.Entity<Pedido>().HasKey(p => p.Id);
            builder.Entity<Pedido>().Property(p => p.Id).IsRequired();
            builder.Entity<Pedido>().Property(p => p.Cliente).IsRequired().HasMaxLength(30);  
            builder.Entity<Pedido>().Property(p => p.ValorTotalPedido).HasColumnType("decimal(5,3)").IsRequired();
            builder.Entity<Pedido>().HasOne<Tamanho>(p => p.Tamanho).WithMany(p => p.Pedidos).HasForeignKey(p => p.TamanhoId);
            builder.Entity<Pedido>().HasOne<Sabor>(p => p.Sabor).WithMany(p => p.Pedidos).HasForeignKey(p => p.SaborId);
        }

        private void ModelBuilderTamanho(ModelBuilder builder){
            builder.Entity<Tamanho>().ToTable("Tamanho");
            builder.Entity<Tamanho>().HasKey(p => p.Id);
            builder.Entity<Tamanho>().Property(p => p.Id).IsRequired();
            builder.Entity<Tamanho>().Property(p => p.Descricao).IsRequired().HasMaxLength(30); 
            builder.Entity<Tamanho>().Property(p => p.Ml).IsRequired().HasMaxLength(6); 
            builder.Entity<Tamanho>().Property(p => p.TempoMinutos).IsRequired(); 
            builder.Entity<Tamanho>().Property(p => p.Valor).HasColumnType("decimal(5,3)").IsRequired(); 
        }

        private void ModelBuilderSabor(ModelBuilder builder){
            builder.Entity<Sabor>().ToTable("Sabor");
            builder.Entity<Sabor>().HasKey(p => p.Id);
            builder.Entity<Sabor>().Property(p => p.Id).IsRequired();
            builder.Entity<Sabor>().Property(p => p.Descricao).IsRequired().HasMaxLength(30); 
            builder.Entity<Sabor>().Property(p => p.TempoMinutos).IsRequired(); 
        }

        private void ModelBuilderAdicional(ModelBuilder builder){
            builder.Entity<Adicional>().ToTable("Adicional");
            builder.Entity<Adicional>().HasKey(p => p.Id);
            builder.Entity<Adicional>().Property(p => p.Id).IsRequired();
            builder.Entity<Adicional>().Property(p => p.Descricao).IsRequired().HasMaxLength(30); 
            builder.Entity<Adicional>().Property(p => p.TempoMinutos).IsRequired(); 
            builder.Entity<Adicional>().Property(p => p.Valor).HasColumnType("decimal(5,3)").IsRequired(); 
        }

        private void ModelBuilderPedidoAdicional(ModelBuilder builder){
            builder.Entity<PedidoAdicional>().ToTable("Pedido_Adicional");
            builder.Entity<PedidoAdicional>().HasKey(p => new {p.AdicionalId, p.PedidoId});
            builder.Entity<PedidoAdicional>().Property(p => p.AdicionalId).IsRequired();
            builder.Entity<PedidoAdicional>().Property(p => p.PedidoId).IsRequired();
            builder.Entity<PedidoAdicional>().HasOne(p => p.Pedido).WithMany(p => p.pedidoAdicionals).HasForeignKey(p => p.PedidoId);
            builder.Entity<PedidoAdicional>().HasOne(p => p.Adicional).WithMany(p => p.pedidoAdicionals).HasForeignKey(p => p.AdicionalId);
        }
    }
}