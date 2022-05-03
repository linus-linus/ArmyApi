#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArmyAPI.Models;

namespace ArmyAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class WeaponController : ControllerBase
{
    private readonly ArmyContext _context;

    public WeaponController (ArmyContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Weapon>>> GetWeapons()
    {
        List<Weapon> weapons = await _context.Weapon.ToListAsync();
        return weapons;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Weapon>> Get(int id)
    {
        Weapon weapon = await _context.Weapon.FindAsync(id);
        return weapon;
    }

    [HttpGet("{type}")]
    [Route("[action]/{type}")]
    public async Task<ActionResult<List<Weapon>>> Get(string type)
    {        
        List<Weapon> weapons = await _context.Weapon
            .Where( 
                weapon => weapon.Type.ToLower().Contains(type.ToLower()) 
            )
            .ToListAsync();

        return weapons;  
    }


    [HttpPut]
    public async Task<ActionResult<Weapon>> Put(Weapon editedWeapon)
    {
        _context.Entry(editedWeapon).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return editedWeapon;
    }

    [HttpPost]
    public async Task<ActionResult<Weapon>> Post(Weapon newWeapon)
    {
        _context.Weapon.Add(newWeapon);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("Get", new { id = newWeapon.Id}, newWeapon);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        Weapon weapon = await _context.Weapon.FindAsync(id);
        _context.Weapon.Remove(weapon);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}

