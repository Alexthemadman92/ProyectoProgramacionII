using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    // Puedes agregar propiedades personalizadas para los usuarios si es necesario
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
}
