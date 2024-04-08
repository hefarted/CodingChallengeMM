using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodingChallengeMM.Server.Data;
using CodingChallengeMM.Server.Model;

namespace CodingChallengeMM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerRequest>>> GetCustomerRequests()
        {
            return await _context.CustomerRequests.ToListAsync();
        }

        // GET: api/CustomerRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerRequest>> GetCustomerRequest(int id)
        {
            var customerRequest = await _context.CustomerRequests.FindAsync(id);

            if (customerRequest == null)
            {
                return NotFound();
            }

            return customerRequest;
        }

        // PUT: api/CustomerRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerRequest(int id, CustomerRequest customerRequest)
        {
            if (id != customerRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerRequestExists(id))
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

        // POST: api/CustomerRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerRequest>> PostCustomerRequest(CustomerRequest customerRequest)
        {
            _context.CustomerRequests.Add(customerRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerRequest", new { id = customerRequest.Id }, customerRequest);
        }

        // DELETE: api/CustomerRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerRequest(int id)
        {
            var customerRequest = await _context.CustomerRequests.FindAsync(id);
            if (customerRequest == null)
            {
                return NotFound();
            }

            _context.CustomerRequests.Remove(customerRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerRequestExists(int id)
        {
            return _context.CustomerRequests.Any(e => e.Id == id);
        }
    }
}
