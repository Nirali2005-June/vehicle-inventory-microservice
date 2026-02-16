using NS.VehicleInventory.Application.DTOs;
using NS.VehicleInventory.Application.Interfaces;
using VehicleInventory.Domain.Entities;
using VehicleInventory.Domain.Enums;
using VehicleInventory.Domain.Exceptions;

namespace NS.VehicleInventory.Application.Services;

public class VehicleService
{
    private readonly IVehicleRepository _repository;

    public VehicleService(IVehicleRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CreateVehicleAsync(CreateVehicleRequest request)
    {
        
        var vehicle = new Vehicle(
            request.VehicleCode,
            request.LocationId,
            request.VehicleType
        );

        await _repository.AddAsync(vehicle);

        return vehicle.Id;
    }

    public async Task<List<VehicleResponse>> GetAllVehiclesAsync()
    {
        var vehicles = await _repository.GetAllAsync();

        return vehicles.Select(v => new VehicleResponse
        {
            Id = v.Id,
            VehicleCode = v.VehicleCode,
            LocationId = v.LocationId,
            VehicleType = v.VehicleType,
            Status = v.Status.ToString()
        }).ToList();
    }

    
    public async Task<VehicleResponse?> GetVehicleByIdAsync(int id)
    {
        var vehicle = await _repository.GetByIdAsync(id);

        if (vehicle == null)
            return null;

        return new VehicleResponse
        {
            Id = vehicle.Id,
            VehicleCode = vehicle.VehicleCode,
            LocationId = vehicle.LocationId,
            VehicleType = vehicle.VehicleType,
            Status = vehicle.Status.ToString()
        };
    }

    
    public async Task UpdateVehicleStatusAsync(int id, UpdateVehicleStatusRequest request)
    {
        var vehicle = await _repository.GetByIdAsync(id);

        if (vehicle == null)
            throw new DomainException("Vehicle not found.");

        if (!Enum.TryParse<VehicleStatus>(request.Status, true, out var newStatus))
            throw new DomainException("Invalid vehicle status.");

        switch (newStatus)
        {
            case VehicleStatus.Rented:
                vehicle.MarkRented();
                break;

            case VehicleStatus.Reserved:
                vehicle.MarkReserved();
                break;

            case VehicleStatus.Available:
                vehicle.MarkAvailable();
                break;

            case VehicleStatus.InService:
                vehicle.MarkServiced();
                break;
        }

        await _repository.UpdateAsync(vehicle);
    }

    public async Task DeleteVehicleAsync(int id)
    {
        var vehicle = await _repository.GetByIdAsync(id);

        if (vehicle == null)
            throw new DomainException("Vehicle not found.");

        await _repository.DeleteAsync(vehicle);
    }
}
