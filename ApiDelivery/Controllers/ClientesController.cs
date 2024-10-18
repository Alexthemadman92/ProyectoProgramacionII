using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("api/clientes")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public ActionResult<List<Cliente>> GetAllClientes()
    {

        return Ok(_clienteService.GetAll());
    }
    [HttpGet("{id}")]
    public ActionResult<Cliente> GetById(int id)
    {
        Cliente? c = _clienteService.GetById(id);
        if (c == null)
        {
            return NotFound("Cliente no Encotrado");
        }

        return Ok(c);

    }
    [HttpPost]
    public ActionResult<Cliente> NuevoCliente(ClienteDTO c)
    {
        Cliente _c = _clienteService.Create(c);
        return CreatedAtAction(nameof(GetById), new { id = _c.Id }, _c);
    }
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var c = _clienteService.GetById(id);

        if (c == null)
        { return NotFound("Cliente no encontrado!!!"); }

        _clienteService.Delete(id);
        return NoContent();
    }
    [HttpPut("{id}")]
    public ActionResult<Cliente> UpdateCliente(int id, Cliente updatedCliente)
    {
        if (id != updatedCliente.Id)
        {
            return BadRequest("El ID del cliente en la URL no coincide con el ID del cliente en el cuerpo de la solicitud.");
        }
        var cliente = updatedCliente.Update(id, updatedCliente);

        if (cliente is null)
        {
            return NotFound(); 
        }
        return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
    }
}