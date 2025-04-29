using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lucky7_Inventory_System_Domain.Entities;

public class Transaction
{
    public int TransactionId { get; set; }
    public string? UserId { get; set; }
    public DateTime? CreatedDate { get; set; }

    [Precision(18, 2)]
    public decimal? TotalAmount { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }

    public ICollection<TransactionItem>? TransactionItems { get; set; }
}