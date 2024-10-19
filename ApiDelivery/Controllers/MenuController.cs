using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/MenuItens")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet]
    public ActionResult<List<MenuItem>> GetAllItems()
    {
        return Ok(_menuService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<MenuItem> GetById(int id)
    {
        menuItem? m = _menuService.GetById(id);
        if (m == null) return NotFound("Item no encontrado");
        return Ok(m);
    }

    [HttpPost]
    public ActionResult<MenuItem> NuevoItem(MenuItemDTO m)
    {
        MenuItem _m = _menuService.Create(m);
        return CreatedAtAction(nameof(GetById), new { id = _m.Id }, _m);
    }

    [HttpPut("{id}")]
    public ActionResult<MenuItem> UpdateMenuItem(int id, MenuItemDTO updateMenuItem)
    {
        var item = _menuService.Update(id, updateMenuItem);
        if (item is null) return NotFound();
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var m = _menuService.GetById(id);

        if (m == null)
        { return NotFound("Item no encontrado!!!"); }

        _menuService.Delete(id);
        return NoContent();
    }
}
