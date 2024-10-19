using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/pedidos")]
public class PedidosController : ControllerBase
{
    private readonly IPedidoService _pedidoService;


    public PedidosController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public ActionResult<List<Pedido>> GetAll()
    {
        try
        {
            return Ok(_pedidoService.GetAll());
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return Problem(detail: e.Message, statusCode: 500);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Pedido> GetById(int id)
    {
        Pedido? pedido = _pedidoService.GetById(id);
        if (pedido is null) return NotFound();
        return Ok(pedido);
    }

    [HttpGet("estado/{estado}")]
    public ActionResult<Pedido> GetByEstado(string estado)
    {
        Pedido? estado = _pedidoService.GetByEstado(estado);
        if (estado is null) return NotFound();
        return Ok(estado);
    }

    [HttpGet("fecha/{fecha}")]
    public ActionResult<Pedido> GetByFecha(DateTime fecha)
    {
        Pedido? fecha = _pedidoService.GetByFecha(fecha);
        if (fecha is null) return NotFound();
        return Ok(fecha);
    }

    [HttpGet("cliente/{clienteId}")]
    public ActionResult<Pedido> GetByCliente(int clienteId)
    {
        Pedido? clienteId = _pedidoService.GetByCliente(clienteId);
        if (clienteId is null) return NotFound();
        return Ok(clienteId);
    }

    [HttpPost]
    public ActionResult<Pedido> NuevoPedido(PedidoDTO p)
    {
        Pedido pedido = _pedidoService.Create(p)
        return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
    }

    [HttpPut("{id}")]
    public ActionResult<Pedido> Update(int id, PedidoDTO p)
    {
        try
        {
            Pedido pedido = _pedidoService.Update(id, p);
            if (pedido is null) return NotFound(new { message = $"No se puede actualizar el pedido con id: {id}" });
            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return Problem(detail: e.Message, statusCode: 500);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        bool deleted = _pedidoService.Delete(id);
        if (deleted) return NoContent();
        return NotFound();
    }
}
