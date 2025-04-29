using Microsoft.EntityFrameworkCore;

namespace Lucky7_Inventory_System_Domain.Entities;

public class Item
{
    public int ItemId { get; set; }
    public string? ItemName { get; set; }
    public string? Desciption { get; set; }
    public string? Sku { get; set; }
    public string? Brand { get; set; }
    public int? QuantityInStock { get; set; }

    [Precision(18, 2)]
    public decimal? UnitPrice { get; set; }

    public int? UomId { get; set; }
    public string? ImageUrl { get; set; }
    public int? StatusId { get; set; }
    public int? CategoryId { get; set; }
    public Status? Status { get; set; }
    public Category? Category { get; set; }
    public Uom? Uom { get; set; }
}