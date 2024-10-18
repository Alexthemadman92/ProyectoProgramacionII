public interface IPedidoService
{
    Task<IEnumerable<Pedido>> GetPedidos();
    Task<Pedido> GetPedidoById(int id);
    Task<IEnumerable<Pedido>> GetPedidosByEstado(string estado);
    Task<IEnumerable<Pedido>> GetPedidosByFecha(DateTime fecha);
    Task<IEnumerable<Pedido>> GetPedidosByCliente(int clienteId);
    Task AddPedido(Pedido pedido);
    Task UpdatePedido(Pedido pedido);
    Task DeletePedido(int id);
}