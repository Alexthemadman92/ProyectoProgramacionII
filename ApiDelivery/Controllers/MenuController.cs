using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
    {
        return Ok(await _menuService.GetMenuItems());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
    {
        var menuItem = await _menuService.GetMenuItemById(id);
        if (menuItem == null) return NotFound();
        return Ok(menuItem);
    }

    [HttpPost]
    public async Task<ActionResult> AddMenuItem(MenuItem menuItem)
    {
        await _menuService.AddMenuItem(menuItem);
        return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.Id }, menuItem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateMenuItem(int id, MenuItem menuItem)
    {
        if (id != menuItem.Id) return BadRequest();
        await _menuService.UpdateMenuItem(menuItem);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMenuItem(int id)
    {
        await _menuService.DeleteMenuItem(id);
        return NoContent();
    }
}
