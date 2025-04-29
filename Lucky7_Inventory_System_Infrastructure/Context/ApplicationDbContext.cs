using Lucky7_Inventory_System_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lucky7_Inventory_System_Infrastructure.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditTrail> AuditTrail { get; set; }
    public virtual DbSet<Cart> Cart { get; set; }
    public virtual DbSet<CartItem> CartItem { get; set; }
    public virtual DbSet<Category> Category { get; set; }
    public virtual DbSet<Item> Item { get; set; }
    public virtual DbSet<RefCode> RefCode { get; set; }
    public virtual DbSet<RefType> RefType { get; set; }
    public virtual DbSet<Role> Role { get; set; }
    public virtual DbSet<Status> Status { get; set; }
    public virtual DbSet<Transaction> Transaction { get; set; }
    public virtual DbSet<TransactionItem> TransactionItem { get; set; }
    public virtual DbSet<Uom> Uom { get; set; }
    public virtual DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}