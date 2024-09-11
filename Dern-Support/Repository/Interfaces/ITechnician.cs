using Dern_Support.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dern_Support.Interfaces
{
    public interface ITechnician
    {
        // Method to view all support requests
        Task<List<SupportRequest>> ViewSupportRequests();

        // Method to update the status of a support request (approve/decline)
        Task UpdateSupportRequestStatus(int requestId, string status);

        // Method to log out the technician
        Task LogoutTechnician();

        // Method to view all inventory items
        Task<List<InventoryItem>> ViewInventoryItems();

        // Method to update the quantity of an inventory item
        Task UpdateInventoryItem(int itemId, InventoryItem updatedItem);
    }
}
