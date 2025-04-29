namespace Lucky7_Inventory_System_Domain.Entities;

public class RefCode
{
    public int? RefCodeId { get; set; }
    public string? RefCodeName { get; set; }
    public int? RefTypeId { get; set; }
    public RefType? RefType { get; set; }
}