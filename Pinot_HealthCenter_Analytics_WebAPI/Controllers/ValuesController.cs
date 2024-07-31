using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pinot_HealthCenter_Analytics_WebAPI.Data;
using Pinot_HealthCenter_Analytics_WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ProvidersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProvidersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Providers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Provider>>> GetProviders()
    {
        return await _context.Providers.ToListAsync();
    }

    // GET: api/Providers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Provider>> GetProvider(int id)
    {
        var provider = await _context.Providers.FindAsync(id);

        if (provider == null)
        {
            return NotFound();
        }

        return provider;
    }

    // POST: api/Providers
    [HttpPost]
    public async Task<ActionResult<Provider>> PostProvider(Provider provider)
    {
        _context.Providers.Add(provider);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProvider", new { id = provider.ProviderID }, provider);
    }

    // PUT: api/Providers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProvider(int id, Provider provider)
    {
        if (id != provider.ProviderID)
        {
            return BadRequest();
        }

        _context.Entry(provider).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProviderExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Providers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProvider(int id)
    {
        var provider = await _context.Providers.FindAsync(id);
        if (provider == null)
        {
            return NotFound();
        }

        _context.Providers.Remove(provider);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProviderExists(int id)
    {
        return _context.Providers.Any(e => e.ProviderID == id);
    }
}