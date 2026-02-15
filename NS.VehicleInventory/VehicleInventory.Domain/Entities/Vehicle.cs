using VehicleInventory.Domain.Enums;
using VehicleInventory.Domain.Exceptions;

namespace VehicleInventory.Domain.Entities;

public class Vehicle
{
    public Guid Id { get; private set; }
    public string VehicleCode { get; private set; }
    public string LocationId { get; private set; }
    public string VehicleType { get; private set; }
    public VehicleStatus Status { get; private set; }

    // Required by EF Core
    private Vehicle() { }

    public Vehicle(Guid id, string vehicleCode, string locationId, string vehicleType)
    {
        if (string.IsNullOrWhiteSpace(vehicleCode))
            throw new DomainException("Vehicle code is required.");

        if (string.IsNullOrWhiteSpace(locationId))
            throw new DomainException("Location ID is required.");

        if (string.IsNullOrWhiteSpace(vehicleType))
            throw new DomainException("Vehicle type is required.");

        Id = id;
        VehicleCode = vehicleCode;
        LocationId = locationId;
        VehicleType = vehicleType;
        Status = VehicleStatus.Available;
    }

    public void MarkRented()
    {
        if (Status == VehicleStatus.Rented)
            throw new DomainException("Vehicle is already rented.");

        if (Status == VehicleStatus.Reserved)
            throw new DomainException("Reserved vehicle cannot be rented.");

        if (Status == VehicleStatus.InService)
            throw new DomainException("Vehicle under service cannot be rented.");

        Status = VehicleStatus.Rented;
    }

    public void MarkReserved()
    {
        if (Status != VehicleStatus.Available)
            throw new DomainException("Only available vehicles can be reserved.");

        Status = VehicleStatus.Reserved;
    }

    public void MarkAvailable()
    {
        if (Status == VehicleStatus.Reserved)
            throw new DomainException("Reserved vehicle must be released before becoming available.");

        Status = VehicleStatus.Available;
    }

    public void MarkServiced()
    {
        Status = VehicleStatus.InService;
    }
}