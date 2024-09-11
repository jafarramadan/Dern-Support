using Dern_Support.Interfaces;
using Dern_Support.Models;
using Dern_Support.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dern_Support.Repository.Services
{
    public class TechnicianServices : ITechnician
    {
        private readonly DernSupportDbContext _context;

        // Constructor to inject the DbContext
        public TechnicianServices(DernSupportDbContext context)
        {
            _context = context;
        }

        // Method to view all support requests
        public async Task<List<SupportRequest>> ViewSupportRequests()
        {
            return await _context.SupportRequests.ToListAsync();
        }

        // Method to update the status of a support request (approve/decline)
        public async Task UpdateSupportRequestStatus(int requestId, string status)
        {
            var request = await _context.SupportRequests.FindAsync(requestId);
            if (request != null)
            {
                request.Status = status;
                await _context.SaveChangesAsync();
            }
        }

        // Method to log out the technician (placeholder logic)
        public async Task LogoutTechnician()
        {
            // Implement logout logic here
            await Task.CompletedTask;
        }

        // Method to view all inventory items
        public async Task<List<InventoryItem>> ViewInventoryItems()
        {
            return await _context.InventoryItems.ToListAsync();
        }

        // Method to update the quantity of an inventory item
        public async Task UpdateInventoryItem(int itemId, InventoryItem updatedItem)
        {
            var item = await _context.InventoryItems.FindAsync(itemId);
            if (item != null)
            {
                item.Name = updatedItem.Name;  // Update the name
                item.Price = updatedItem.Price; // Update the price
                item.Quantity = updatedItem.Quantity;  // Update the quantity
                                                       // Add any other fields to update

                await _context.SaveChangesAsync();
            }
        }
        // Method to search inventory items by name
        public async Task<List<InventoryItem>> SearchInventoryItemsByName(string name)
        {
            return await _context.InventoryItems
                .Where(item => item.Name.Contains(name))
                .ToListAsync();
        }
    }
}
