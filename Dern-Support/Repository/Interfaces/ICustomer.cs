using Dern_Support.Models;

namespace Dern_Support.Repository.Interfaces
{
    public interface ICustomer
    {
        // Method for submitting a support request
        Task SubmitSupportRequest(SupportRequest request);

        // Method for logging out the customer
        Task LogoutCustomer();

        // Method for viewing inventory items
        Task<List<InventoryItem>> ViewInventoryItems();
        // Method for getting support requests by customer name
        Task<List<SupportRequest>> GetSupportRequestsByCustomerName(string customerName);
    }
}
