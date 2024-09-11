using Dern_Support.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Dern_Support.Data
{
    public class DernSupportDbContext : IdentityDbContext<ApplicationUser>
    {
        public DernSupportDbContext(DbContextOptions<DernSupportDbContext> options) : base(options)
        {

        }
        public DbSet<SupportRequest> SupportRequests { get; set; }
        public DbSet<RepairJob> RepairJobs { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<KnowledgeBaseArticle> KnowledgeBaseArticles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
           


            seedRoles(modelBuilder);
            // Seed inventory items
            modelBuilder.Entity<InventoryItem>().HasData(
                new InventoryItem
                {
                    Id = 1,
                    Name = "Laptop",
                    Quantity = 50,
                    Price = 999.99m
                },
                new InventoryItem
                {
                    Id = 2,
                    Name = "Hard Disk 1TB",
                    Quantity = 100,
                    Price = 79.99m
                },
                new InventoryItem
                {
                    Id = 3,
                    Name = "RAM 16GB",
                    Quantity = 75,
                    Price = 129.99m
                },
                new InventoryItem
                {
                    Id = 4,
                    Name = "Laptop Charger",
                    Quantity = 40,
                    Price = 49.99m
                },
                new InventoryItem
                {
                    Id = 5,
                    Name = "SSD 500GB",
                    Quantity = 60,
                    Price = 89.99m
                }
            );

        }

        private void seedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                
                new IdentityRole
                {
                    Id = "1",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Technician",
                    NormalizedName = "TECHNICIAN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            );
        }


    }
}