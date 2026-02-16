using Microsoft.AspNetCore.Mvc;
using NS.VehicleInventory.Application.Services;
using NS.VehicleInventory.Application.DTOs;

namespace NS.VehicleInventory.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly VehicleService _vehicleService;

    public VehiclesController(VehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vehicles = await _vehicleService.GetAllVehiclesAsync();
        return Ok(vehicles);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateVehicleRequest request)
    {
        var result = await _vehicleService.CreateVehicleAsync(request);
        return Ok(result);
    }
}
