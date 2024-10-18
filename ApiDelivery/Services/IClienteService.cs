public interface IClienteService
{
    Task<IEnumerable<Cliente>> GetClientes();
    Task<Cliente> GetClienteById(int id);
    Task AddCliente(Cliente cliente);
    Task UpdateCliente(Cliente cliente);
    Task DeleteCliente(int id);
}