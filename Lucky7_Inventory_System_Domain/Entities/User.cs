namespace Lucky7_Inventory_System_Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Password { get; set; }
    public int RoleId { get; set; }
    public int StatusId { get; set; }
}
