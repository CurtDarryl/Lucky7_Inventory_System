using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lucky7_Inventory_System_Domain.Entities;

public class CartItem
{
    public int CartItemId { get; set; }
    public int? CartId { get; set; }
    public int? ItemId { get; set; }

    [Precision(18, 2)]
    public decimal? Quantity { get; set; }

    [Precision(18, 2)]
    public decimal? UnitPrice { get; set; }

    public Cart? Cart { get; set; }
    public Item? Item { get; set; }
}