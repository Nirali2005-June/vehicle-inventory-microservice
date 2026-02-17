using System.ComponentModel.DataAnnotations;

namespace NS.VehicleInventory.Application.DTOs;

public class CreateVehicleRequest
{
    [Required]
    [MaxLength(50)]
    public string VehicleCode { get; set; } = string.Empty;

    [Required]
    public string LocationId { get; set; } = string.Empty;

    [Required]
    public string VehicleType { get; set; } = string.Empty;
}