using System.ComponentModel.DataAnnotations;

public class ClienteDTO
{
  [Required(ErrorMessage = "El campo Nombre es requerido.")]
  public string? Nombre { get; set; }
  [Required(ErrorMessage = "El campo Apellido es requerido.")]
  public string? Apellido { get; set; }
  [Required(ErrorMessage = "El campo Direccion es requerido.")]
  public string? Direccion { get; set; }
  [Required(ErrorMessage = "El campo Telefono es requerido.")]
  public int? Telefono { get; set; }

}