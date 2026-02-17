using System.ComponentModel.DataAnnotations;

namespace NS.VehicleInventory.Application.DTOs;

public class UpdateVehicleStatusRequest
{
    [Required]
    public string Status { get; set; } = string.Empty;
}
