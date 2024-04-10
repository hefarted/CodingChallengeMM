using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodingChallengeMM.Server.Data;
using CodingChallengeMM.Server.Entities;

namespace CodingChallengeMM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistedDomainsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlacklistedDomainsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BlacklistedDomains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlacklistedDomain>>> GetBlacklistedDomains()
        {
            return await _context.BlacklistedDomains.ToListAsync();
        }

        // GET: api/BlacklistedDomains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlacklistedDomain>> GetBlacklistedDomain(int id)
        {
            var blacklistedDomain = await _context.BlacklistedDomains.FindAsync(id);

            if (blacklistedDomain == null)
            {
                return NotFound();
            }

            return blacklistedDomain;
        }

        // PUT: api/BlacklistedDomains/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlacklistedDomain(int id, BlacklistedDomain blacklistedDomain)
        {
            if (id != blacklistedDomain.Id)
            {
                return BadRequest();
            }

            _context.Entry(blacklistedDomain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlacklistedDomainExists(id))
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

        // POST: api/BlacklistedDomains
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlacklistedDomain>> PostBlacklistedDomain(BlacklistedDomain blacklistedDomain)
        {
            _context.BlacklistedDomains.Add(blacklistedDomain);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlacklistedDomain", new { id = blacklistedDomain.Id }, blacklistedDomain);
        }

        // DELETE: api/BlacklistedDomains/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlacklistedDomain(int id)
        {
            var blacklistedDomain = await _context.BlacklistedDomains.FindAsync(id);
            if (blacklistedDomain == null)
            {
                return NotFound();
            }

            _context.BlacklistedDomains.Remove(blacklistedDomain);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlacklistedDomainExists(int id)
        {
            return _context.BlacklistedDomains.Any(e => e.Id == id);
        }
    }
}
