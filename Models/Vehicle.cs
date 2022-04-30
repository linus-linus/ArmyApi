using System.ComponentModel.DataAnnotations;

namespace ArmyAPI.Models;

public class Vehicle
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Country { get; set; }
    public double Weight { get; set; }
    public Boolean? Weaponized { get; set; }
    public int TopSpeed { get; set; }
    public string? Category { get; set; }

}