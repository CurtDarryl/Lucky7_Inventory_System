namespace Lucky7_Inventory_System_Domain.Entities;

public class Role
{
    public int RoleId { get; set; }
    public string? RoleName { get; set; }
    public int? StatusId { get; set; }
    public Status? Status { get; set; } = null!;
}
