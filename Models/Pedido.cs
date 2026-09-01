namespace LibreriaSparrow.Api.Models;

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }

    public DateTime FechaPedido { get; set; } = DateTime.UtcNow;
    public string TipoEnvio { get; set; } = string.Empty;
    public decimal CostoEnvio { get; set; }
    public string MetodoPago { get; set; } = string.Empty;
    public string EstadoEnvio { get; set; } = "Pendiente";
    public decimal TotalFinal { get; set; }

    public List<DetallePedido> Detalles { get; set; } = [];
}