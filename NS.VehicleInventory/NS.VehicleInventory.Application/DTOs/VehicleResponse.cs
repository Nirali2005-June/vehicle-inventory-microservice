namespace NS.VehicleInventory.Application.DTOs;

public class VehicleResponse
{
    public int Id { get; set; }
    public string VehicleCode { get; set; } = string.Empty;
    public string LocationId { get; set; } = string.Empty;
    public string VehicleType { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}