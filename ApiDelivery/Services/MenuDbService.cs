public class MenuDbService : IMenuService
{
    private readonly DeliveryContext _context;

    public MenuDbService(DeliveryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MenuItem>> GetMenuItems()
    {
        return await _context.MenuItems.ToListAsync();
    }

    public async Task<MenuItem> GetMenuItemById(int id)
    {
        return await _context.MenuItems.FindAsync(id);
    }

    public async Task AddMenuItem(MenuItem menuItem)
    {
        _context.MenuItems.Add(menuItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMenuItem(MenuItem menuItem)
    {
        _context.MenuItems.Update(menuItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMenuItem(int id)
    {
        var menuItem = await _context.MenuItems.FindAsync(id);
        if (menuItem != null)
        {
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
        }
    }
}
