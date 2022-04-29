using System.ComponentModel.DataAnnotations;

namespace ArmyAPI.Models;

public class Soldier
{
    [Key]

    public int Id { get; set;}
    public string? FirstName { get; set;}
    public string? LastName { get; set;}
    public int Age { get; set;}
    public string? Department { get; set;}
    public string? JobTitle {get; set;} 
    public string? Rank {get; set;} 
    public string? Image {get; set;} 

}

