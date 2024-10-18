public class Pedido
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public Cliente Cliente { get; set; }
    public List<MenuItem> ItemsSolicitados { get; set; }
    public string Estado { get; set; } // ingresado, en proceso, enviado, entregado
}