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
}