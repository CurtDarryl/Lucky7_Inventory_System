using System.ComponentModel.DataAnnotations;
using UtilityKit.Utils;

namespace Lucky7_Inventory_System_Domain.Entities;

public class User
{
    [Key] 
    public string UserId { get; set; } = IdGenerator.Generate(8);
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Password { get; set; }
    public int RoleId { get; set; }
    public int StatusId { get; set; }
    public Role? Role { get; set; } = null!;
    public Status? Status { get; set; } = null!;
}
