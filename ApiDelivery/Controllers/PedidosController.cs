using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

[Route("api/[controller]")]
[ApiController]
public class PedidosController : ControllerBase
{
    private readonly IPedidoService _pedidoService;

    public PedidosController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
    {
        return Ok(await _pedidoService.GetPedidos());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pedido>> GetPedido(int id)
    {
        var pedido = await _pedidoService.GetPedidoById(id);
        if (pedido == null) return NotFound();
        return Ok(pedido);
    }

    [HttpGet("estado/{estado}")]
    public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidosByEstado(string estado)
    {
        return Ok(await _pedidoService.GetPedidosByEstado(estado));
    }

    [HttpGet("fecha/{fecha}")]
    public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidosByFecha(DateTime fecha)
    {
        return Ok(await _pedidoService.GetPedidosByFecha(fecha));
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidosByCliente(int clienteId)
    {
        return Ok(await _pedidoService.GetPedidosByCliente(clienteId));
    }

    [HttpPost]
    public async Task<ActionResult> AddPedido(Pedido pedido)
    {
        await _pedidoService.AddPedido(pedido);
        return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePedido(int id, Pedido pedido)
    {
        if (id != pedido.Id) return BadRequest();
        await _pedidoService.UpdatePedido(pedido);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePedido(int id)
    {
        await _pedidoService.DeletePedido(id);
        return NoContent();
    }
}
