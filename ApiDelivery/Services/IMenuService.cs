public interface IMenuService
{
    Task<IEnumerable<MenuItem>> GetMenuItems();
    Task<MenuItem> GetMenuItemById(int id);
    Task AddMenuItem(MenuItem menuItem);
    Task UpdateMenuItem(MenuItem menuItem);
    Task DeleteMenuItem(int id);
}
