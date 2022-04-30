#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArmyAPI.Models;

namespace ArmyAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class SoldierController : ControllerBase
{
    private readonly ArmyContext _context;

    public SoldierController (ArmyContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<List<Soldier>>> GetSoldiers()
    {
        List<Soldier> soldiers = await _context.Soldier.ToListAsync(); 
        return soldiers;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Soldier>> Get(int id)
    {
        Soldier soldier = await _context.Soldier.FindAsync(id);
        return soldier;

        //Legg inn if/else !!!!!!!!!!!!!!!!!
    }

    [HttpPut]
    public async Task<ActionResult<Soldier>> Put(Soldier editedInfo)
    {
        _context.Entry(editedInfo).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return editedInfo;
    }
    
    [HttpPost]
    public async Task<ActionResult<Soldier>> Post(Soldier newSoldier)
    {
        _context.Soldier.Add(newSoldier);
        await _context.SaveChangesAsync(); 

        return CreatedAtAction("Get", new { id = newSoldier.Id}, newSoldier);
    }
 }