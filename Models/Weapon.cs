using System.ComponentModel.DataAnnotations;

namespace ArmyAPI.Models;

public class Weapon
{
    [Key]

    public int Id { get; set; }
    public string? Type { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public int Capacity { get; set; }
    public string? RateOfFire { get; set; }
    public Boolean? Damage { get; set; }

}