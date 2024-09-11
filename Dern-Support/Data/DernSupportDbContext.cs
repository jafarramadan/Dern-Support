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

            modelBuilder.Entity<KnowledgeBaseArticle>().HasData(
       new KnowledgeBaseArticle
       {
           Id = 1,
           Title = "How to Fix Common Printer Issues",
           Content = "If your printer is not working properly, follow these steps: 1. Check the printer's connection to your computer. 2. Ensure that the printer has enough paper and ink. 3. Restart both your computer and printer. If these steps do not resolve the issue, consult the printer's manual or contact support.",
           PublishedDate = new DateTime(2024, 9, 11)
       },
       new KnowledgeBaseArticle
       {
           Id = 2,
           Title = "Troubleshooting Internet Connectivity Problems",
           Content = "To troubleshoot internet connectivity issues: 1. Verify that your modem and router are properly connected. 2. Check if other devices are able to connect to the internet. 3. Restart your modem and router. If the problem persists, contact your internet service provider.",
           PublishedDate = new DateTime(2024, 9, 10)
       },
       new KnowledgeBaseArticle
       {
           Id = 3,
           Title = "Steps to Resolve Computer Overheating",
           Content = "If your computer is overheating, try the following steps: 1. Ensure that the computer's cooling vents are not blocked. 2. Clean the internal components to remove dust buildup. 3. Check that the cooling fans are working properly. If the issue continues, consider seeking professional assistance.",
           PublishedDate = new DateTime(2024, 9, 9)
       }
   );

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