public class PedidoDbService : IPedidoService
{
    private readonly DeliveryContext _context;

    public PedidoDbService(DeliveryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pedido>> GetPedidos()
    {
        return await _context.Pedidos.Include(p => p.Cliente).Include(p => p.ItemsSolicitados).ToListAsync();
    }

    public async Task<Pedido> GetPedidoById(int id)
    {
        return await _context.Pedidos.Include(p => p.Cliente).Include(p => p.ItemsSolicitados)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Pedido>> GetPedidosByEstado(string estado)
    {
        return await _context.Pedidos.Include(p => p.Cliente).Include(p => p.ItemsSolicitados)
            .Where(p => p.Estado == estado).ToListAsync();
    }

    public async Task<IEnumerable<Pedido>> GetPedidosByFecha(DateTime fecha)
    {
        return await _context.Pedidos.Include(p => p.Cliente).Include(p => p.ItemsSolicitados)
            .Where(p => p.Fecha.Date == fecha.Date).ToListAsync();
    }

    public async Task<IEnumerable<Pedido>> GetPedidosByCliente(int clienteId)
    {
        return await _context.Pedidos.Include(p => p.Cliente).Include(p => p.ItemsSolicitados)
            .Where(p => p.Cliente.Id == clienteId).ToListAsync();
    }

    public async Task AddPedido(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePedido(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePedido(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
        if (pedido != null)
        {
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
