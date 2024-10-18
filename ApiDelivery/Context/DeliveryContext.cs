using Microsoft.EntityFrameworkCore;

public class DeliveryContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<MenuIten> MenuItens { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }

    public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(a => a.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Apellido).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Direccion).IsRequired().HasMaxLength(350);
            entity.Property(a => a.Telefono).IsRequired().HasMaxLength(20);
        });

        modelBuilder.Entity<MenuIten>(entity =>
        {
            entity.Property(b => b.Nombre).IsRequired();
            entity.Property(b => b.Descripcion).IsRequired();
            entity.Property(b => b.Precio).IsRequired();
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.Property(c => c.FechaPedido).IsRequired();
            entity.Property(c => c.Estado).IsRequired();

            entity.HasOne(c => c.Cliente)
            .HasForeignKey(c => c.ClienteId).IsRequired();

            entity.HasMany(c => c.MenuItens)
            .UsingEntity(d => d.ToTable("PedidoMenuIten"));
        });
    }

}
