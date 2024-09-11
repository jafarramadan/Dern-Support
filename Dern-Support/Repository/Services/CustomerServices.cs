using Dern_Support.Models;
using Dern_Support.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dern_Support.Repository.Interfaces;

namespace Dern_Support.Repository.Services
{
    public class CustomerServices : ICustomer
    {
        private readonly DernSupportDbContext _context;

        // Constructor to inject the DbContext
        public CustomerServices(DernSupportDbContext context)
        {
            _context = context;
        }

        // Method to submit a support request
        public async Task SubmitSupportRequest(SupportRequest request)
        {
            _context.SupportRequests.Add(request);
            await _context.SaveChangesAsync();
        }

        // Method to log out the customer (placeholder for logout logic)
        public async Task LogoutCustomer()
        {
            await Task.CompletedTask;
        }

        // Method to view all inventory items
        public async Task<List<InventoryItem>> ViewInventoryItems()
        {
            return await _context.InventoryItems.ToListAsync();
        }

        public async Task<List<SupportRequest>> GetSupportRequestsByCustomerName(string customerName)
        {
            return await _context.SupportRequests
                                 .Where(sr => sr.CustomerName == customerName)
                                 .ToListAsync();
        }
        // Method to search inventory items by name
        public async Task<List<InventoryItem>> SearchInventoryItemsByName(string name)
        {
            return await _context.InventoryItems
                .Where(item => item.Name.Contains(name))
                .ToListAsync();
        }
        // Method to get all knowledge base articles
        public async Task<List<KnowledgeBaseArticle>> GetKnowledgeBaseArticles()
        {
            return await _context.KnowledgeBaseArticles.ToListAsync();
        }
    }
}
