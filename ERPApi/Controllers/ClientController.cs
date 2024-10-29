using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechtivaERPApi.Models;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly ERPContext _context;

    public ClientController(ERPContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Retrieves the list of clients.
    /// </summary>
    /// <returns>A list of clients or an error message.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClients()
    {
        try
        {
            var clients = await _context.Clients.ToListAsync();

            if (clients == null || clients.Count == 0)
            {
                return NotFound("No clients found.");
            }

            return Ok(clients);
        }
        catch (Exception ex)
        {
            // Log the exception (optional, add logging if needed)
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
