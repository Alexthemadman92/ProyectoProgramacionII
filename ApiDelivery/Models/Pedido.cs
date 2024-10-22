using System.Text.Json.Serialization;

public class Pedido
{
    public int Id { get; set; }
    public string FechaPedido { get; set; }  
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }  
    public string Estado { get; set; }    // Ingresado, En Proceso, Enviado, Entregado
    public virtual List<MenuIten> MenuItens {get; set;}
}
