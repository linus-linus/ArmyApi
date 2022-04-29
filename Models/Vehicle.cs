using System.ComponentModel.DataAnnotations;

namespace ArmyAPI.Models;

public class Vehicle
{
    [Key]
    public int Id { get; set; }
    public string? Type { get; set; }
    public string? Manufacturer { get; set; }
    public int Weight { get; set; }
    public Boolean? Weaponized { get; set; }
    public int TopSpeed { get; set; }

}