using Microsoft.EntityFrameworkCore;

namespace AndreasBank.Models;

public class BancoContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Agencia> Agencias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=andreasbank.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Tabela Agencia
        modelBuilder.Entity<Agencia>(entity =>
        {
            entity.ToTable("Agencias");
            entity.HasKey(a => a.Numero);
            entity.Property(a => a.Numero).IsRequired();
            entity.Property(a => a.Nome).IsRequired();
            entity.Property(a => a.Endereco).IsRequired();
            entity.Property(a => a.Telefone).IsRequired();
            entity.Property(a => a.Email).IsRequired();
            entity.Property(a => a.DataCriacao).IsRequired();
            entity.Property(a => a.Status).IsRequired();
            entity.HasMany(a => a.Contas)
                  .WithOne(c => c.Agencia)
                  .HasForeignKey(c => c.AgenciaNumero)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Tabela Cliente
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Clientes");
            entity.HasKey(c => c.CPF);
            entity.Property(c => c.CPF).IsRequired();
            entity.Property(c => c.Nome).IsRequired();
            entity.Property(c => c.Email).IsRequired();
            entity.Property(c => c.DataNascimento).IsRequired();
            entity.HasMany(c => c.Contas)
                  .WithOne(cn => cn.Titular)
                  .HasForeignKey(cn => cn.TitularCPF)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Tabela Conta
        modelBuilder.Entity<Conta>(entity =>
        {
            entity.ToTable("Contas");
            entity.HasKey(c => c.Numero);
            entity.Property(c => c.Numero).IsRequired();
            entity.Property(c => c.AgenciaNumero).IsRequired();
            entity.Property(c => c.TitularCPF).IsRequired();
            entity.Property(c => c.Saldo).IsRequired();
            entity.Property(c => c.StatusConta).IsRequired();
            entity.Property(c => c.DataCriacao).IsRequired();
            entity.Property(c => c.DataUltimoAcesso).IsRequired();
            entity.Property(c => c.TipoConta).IsRequired();
            entity.HasDiscriminator<EnumTipoConta>("TipoConta")
                .HasValue<ContaCorrente>(EnumTipoConta.Corrente)
                .HasValue<ContaPoupanca>(EnumTipoConta.Poupanca)
                .HasValue<ContaSalario>(EnumTipoConta.Salario);
        });
    }
}