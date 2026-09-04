namespace LibreriaSparrow.Api.DTOs;

public class PedidoDto
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string? ClienteNombre { get; set; }
    public DateTime FechaPedido { get; set; }
    public string TipoEnvio { get; set; } = string.Empty;
    public decimal CostoEnvio { get; set; }
    public string MetodoPago { get; set; } = string.Empty;
    public string EstadoEnvio { get; set; } = string.Empty;
    public decimal TotalFinal { get; set; }
    public List<DetallePedidoDto> Detalles { get; set; } = [];
}

public class DetallePedidoDto
{
    public int LibroId { get; set; }
    public string? LibroTitulo { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
}