namespace Lucky7_Inventory_System_Domain.Entities;

public class AuditTrail
{
    public int AuditTrailId { get; set; }
    public int? Action { get; set; }
    public int? Entity { get; set; }
    public string? Changes { get; set; }
    public string? PerformedBy { get; set; }
    public DateTime? Timestamp { get; set; }
}