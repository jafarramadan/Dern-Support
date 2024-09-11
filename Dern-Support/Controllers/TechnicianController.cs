using Dern_Support.Interfaces;
using Dern_Support.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dern_Support.Controllers
{
    [Authorize(Roles = "Technician")]

    [ApiController]
    [Route("api/[controller]")]
    public class TechnicianController : ControllerBase
    {
        private readonly ITechnician _technicianService;

        // Constructor to inject the technician service
        public TechnicianController(ITechnician technicianService)
        {
            _technicianService = technicianService;
        }

        // GET api/technician/supportrequests
        [HttpGet("supportrequests")]
        public async Task<ActionResult<List<SupportRequest>>> GetSupportRequests()
        {
            var requests = await _technicianService.ViewSupportRequests();
            return Ok(requests);
        }

        // PUT api/technician/supportrequests/{id}
        [HttpPut("supportrequests/{id}")]
        public async Task<IActionResult> UpdateSupportRequestStatus(int id, [FromBody] string status)
        {
            await _technicianService.UpdateSupportRequestStatus(id, status);
            return NoContent();
        }

        // POST api/technician/logout
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _technicianService.LogoutTechnician();
            return NoContent();
        }

        // GET api/technician/inventoryitems
        [HttpGet("inventoryitems")]
        public async Task<ActionResult<List<InventoryItem>>> GetInventoryItems()
        {
            var items = await _technicianService.ViewInventoryItems();
            return Ok(items);
        }

        // PUT api/technician/inventoryitems/{id}
        [HttpPut("inventoryitems/{id}")]
        public async Task<IActionResult> UpdateInventoryItem(int id, [FromBody] InventoryItem updatedItem)
        {
            await _technicianService.UpdateInventoryItem(id, updatedItem);
            return NoContent();
        }
    }
}
