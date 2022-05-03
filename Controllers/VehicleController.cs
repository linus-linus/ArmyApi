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

        if(vehicles != null)
        {
            return Ok(vehicles);
        }
        else{
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> Get(int id)
    {
        Vehicle vehicle = await _context.Vehicle.FindAsync(id);
        return vehicle;

        if(vehicle != null)
        {
            return vehicle;
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("[action]/{category}")]
    public async Task<List<Vehicle>> GetCategory(string category)
    {
        List<Vehicle> vehicle = await _context.Vehicle.Where(_vehicle => _vehicle.Category == category).ToListAsync();
    
        return vehicle;

        if(vehicle != null)
        {
            return vehicle;
        }
        else
        {
            List<Vehicle> emptyList = new List<Vehicle>{
                new Vehicle{Id = -99, Category = "Not Found"}
            };
            return emptyList;
        }
    }

    [HttpPut]
    public async Task<ActionResult<Vehicle>> Put(Vehicle editedVehicle)
    {
        _context.Entry(editedVehicle).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        if(editedVehicle == null)
            {
               return BadRequest("Vehicle is null"); 
            }
            else
            {
                _context.Entry(editedVehicle).State = EntityState.Modified;
                 await _context.SaveChangesAsync();

                return Ok(editedVehicle);
            }
    }

    [HttpPost]
    public async Task<ActionResult<Vehicle>> Post(Vehicle newVehicle)
    {
    _context.Vehicle.Add(newVehicle);
    await _context.SaveChangesAsync();

     if (newVehicle == null)
        {
            return BadRequest();
        }
        else{
            return CreatedAtAction("Get", new { id = newVehicle.Id}, newVehicle);
        }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        Vehicle vehicle = await _context.Vehicle.FindAsync(id);
        _context.Vehicle.Remove(vehicle);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}