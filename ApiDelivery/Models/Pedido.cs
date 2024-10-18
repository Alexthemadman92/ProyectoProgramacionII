using System.Text.Json.Serialization;

public class Pedido
{
    public int Id { get; set; }
    public DateTime FechaPedido { get; set; }  // Asegúrate de que esta propiedad esté definida
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }  // Relación con Cliente
    public string Estado { get; set; }    // Ingresado, En Proceso, Enviado, Entregado
    public List<MenuIten> MenuItens {get; set;}
}
