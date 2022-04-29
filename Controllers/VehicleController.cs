#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArmyAPI.Models;

namespace ArmyAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class VehicleController : ControllerBase
{
    private readonly ArmyContext _context;

    public VehicleController (ArmyContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Vehicle>>> GetVehicles()
    {
        List<Vehicle> vehicles = await _context.Vehicle.ToListAsync();
        return vehicles;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> Get(int id)
    {
        Vehicle vehicle = await _context.Vehicle.FindAsync(id);
        return vehicle;
    }

    [HttpPut]
    public async Task<ActionResult<Vehicle>> Put(Vehicle editedVehicle)
    {
        _context.Entry(editedVehicle).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return editedVehicle;
    }
}