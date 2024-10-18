using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
    {
        return Ok(await _clienteService.GetClientes());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetCliente(int id)
    {
        var cliente = await _clienteService.GetClienteById(id);
        if (cliente == null) return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult> AddCliente(Cliente cliente)
    {
        await _clienteService.AddCliente(cliente);
        return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCliente(int id, Cliente cliente)
    {
        if (id != cliente.Id) return BadRequest();
        await _clienteService.UpdateCliente(cliente);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCliente(int id)
    {
        await _clienteService.DeleteCliente(id);
        return NoContent();
    }
}
