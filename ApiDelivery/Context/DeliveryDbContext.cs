using Microsoft.EntityFrameworkCore;

public class DeliveryDbContext : DbContext
{
    public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración para la entidad Cliente
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Direccion).IsRequired();
            entity.Property(e => e.Telefono).IsRequired().HasMaxLength(20);
        });

        // Configuración para la entidad MenuItem
        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Precio).IsRequired().HasColumnType("decimal(18,2)");
        });

        // Configuración para la entidad Pedido
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FechaPedido).IsRequired();
            entity.Property(e => e.Estado).IsRequired().HasMaxLength(50);

            // Relación Pedido - Cliente (muchos a uno)
            entity.HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.ClienteId);

            // Relación Pedido - MenuItems (muchos a muchos)
            entity.HasMany(p => p.MenuItems)
                .WithMany(mi => mi.Pedidos)
                .UsingEntity(j => j.ToTable("PedidoMenuItems"));
        });
    }
}
