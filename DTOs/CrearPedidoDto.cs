namespace LibreriaSparrow.Api.DTOs;

public class CrearPedidoDto
{
    public int ClienteId { get; set; }
    public string TipoEnvio { get; set; } = string.Empty;
    public decimal CostoEnvio { get; set; }
    public string MetodoPago { get; set; } = string.Empty;
    public List<ItemPedidoDto> Items { get; set; } = [];
}

public class ItemPedidoDto
{
    public int LibroId { get; set; }
    public int Cantidad { get; set; }
}