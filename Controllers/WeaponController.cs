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

        if(weapons != null)
        {
            return Ok(weapons);
        }
        else{
            return NotFound();
        }
        
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Weapon>> Get(int id)
    {
        Weapon weapon = await _context.Weapon.FindAsync(id);

        if(weapon != null)
        {
            return Ok(weapon);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("[action]/{type}")]
    public async Task<List<Weapon>> GetType(string type)
    {        
        List<Weapon> weapon = await _context.Weapon.Where(_weapon => _weapon.Type == type).ToListAsync();
        
        if(weapon != null)
        {
            return weapon;
        }
        else
        {
            List<Weapon> emptyList = new List<Weapon>{
                new Weapon{Id = -99, Type = "Not Found"}
            };
            return emptyList;
        }
        
    }

    [HttpPut]
    public async Task<ActionResult<Weapon>> Put(Weapon editedWeapon)
    {
        _context.Entry(editedWeapon).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        if(editedWeapon is null)
        {
            return BadRequest("Weapon is null");
        }
        else
        {
            return editedWeapon;
        }
        
    }

    [HttpPost]
    public async Task<ActionResult<Weapon>> Post(Weapon newWeapon)
    {
        _context.Weapon.Add(newWeapon);
        await _context.SaveChangesAsync();

        if (newWeapon == null)
        {
            return BadRequest();
        }
        else{
            return CreatedAtAction("Get", new { id = newWeapon.Id}, newWeapon);
        }
        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Weapon weapon = await _context.Weapon.FindAsync(id);
        _context.Weapon.Remove(weapon);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}

