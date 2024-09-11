using Dern_Support.Models;
using Dern_Support.Repository.Interfaces;
using Dern_Support.Repository.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dern_Support.Controllers
{
  [Authorize(Roles = "Customer")]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerService;

        // Constructor to inject the customer service
        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        // POST: api/customer/submit-support-request
        [HttpPost("submit-support-request")]
        public async Task<IActionResult> SubmitSupportRequest( SupportRequest request)
        {
            if (ModelState.IsValid)
            {
                await _customerService.SubmitSupportRequest(request);
                return Ok(new { message = "Support request submitted successfully!" });
            }

            return BadRequest(ModelState);
        }

        // POST: api/customer/logout
        [HttpPost("logout")]
        public async Task<IActionResult> LogoutCustomer()
        {
            await _customerService.LogoutCustomer();
            return Ok(new { message = "Logged out successfully!" });
        }

        // GET: api/customer/inventory-items
        [HttpGet("inventory-items")]
        public async Task<ActionResult<List<InventoryItem>>> ViewInventoryItems()
        {
            var items = await _customerService.ViewInventoryItems();
            return Ok(items);
        }

        // GET: api/customer/support-requests?name=customerName
        [HttpGet("support-requests")]
        public async Task<ActionResult<List<SupportRequest>>> GetSupportRequestsByCustomerName([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest(new { message = "Customer name is required." });
            }

            var requests = await _customerService.GetSupportRequestsByCustomerName(name);
            if (requests == null || requests.Count == 0)
            {
                return NotFound(new { message = "No support requests found for the given customer name." });
            }

            return Ok(requests);
        }
    }
}
