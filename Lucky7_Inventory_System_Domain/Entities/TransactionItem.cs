using Microsoft.EntityFrameworkCore;

namespace Lucky7_Inventory_System_Domain.Entities;

public class TransactionItem
{
    public int TransactionItemId { get; set; }
    public int? TransactionId { get; set; }
    public int? ItemId { get; set; }

    [Precision(18, 2)]
    public decimal? Quantity { get; set; }

    [Precision(18, 2)]
    public decimal? UnitPrice { get; set; }

    public Transaction? Transaction { get; set; }
    public Item? Item { get; set; }
}