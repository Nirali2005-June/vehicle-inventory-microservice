using Microsoft.EntityFrameworkCore;
using NS.VehicleInventory.Application.Interfaces;
using NS.VehicleInventory.Infrastructure.Data;
using VehicleInventory.Domain.Entities;

namespace NS.VehicleInventory.Infrastructure.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly VehicleInventoryDbContext _context;

    public VehicleRepository(VehicleInventoryDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Vehicle vehicle)
    {
        await _context.Vehicles.AddAsync(vehicle);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Vehicle>> GetAllAsync()
    {
        return await _context.Vehicles.ToListAsync();
    }

    public async Task<Vehicle?> GetByIdAsync(int id)
    {
        return await _context.Vehicles
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task UpdateAsync(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Vehicle vehicle)
    {
        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();
    }
}
