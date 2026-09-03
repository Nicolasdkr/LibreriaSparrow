using Microsoft.EntityFrameworkCore;
using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Data;

public class LibreriaContext(DbContextOptions<LibreriaContext> options) : DbContext(options)
{
    public DbSet<Proveedor> Proveedores => Set<Proveedor>();
    public DbSet<Libro> Libros => Set<Libro>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<DetallePedido> DetallesPedido => Set<DetallePedido>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>()
            .Property(l => l.Precio)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<Pedido>()
            .Property(p => p.TotalFinal)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<DetallePedido>()
            .Property(d => d.PrecioUnitario)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.Rut)
            .IsUnique();
    }
}