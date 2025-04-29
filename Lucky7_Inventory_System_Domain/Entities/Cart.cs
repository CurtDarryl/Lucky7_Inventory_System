using System.ComponentModel.DataAnnotations.Schema;

namespace Lucky7_Inventory_System_Domain.Entities;

public class Cart
{
    public int CartId { get; set; }
    public string? UserId { get; set; }
    public DateTime? CreatedDate { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }
    public ICollection<CartItem>? CartItems { get; set; }

}
