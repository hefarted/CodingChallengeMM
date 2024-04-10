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
    public class FinancesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FinancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Finances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Finance>>> GetFinance()
        {
            return await _context.Finance.ToListAsync();
        }

        // GET: api/Finances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Finance>> GetFinance(int id)
        {
            var finance = await _context.Finance.FindAsync(id);

            if (finance == null)
            {
                return NotFound();
            }

            return finance;
        }

        // PUT: api/Finances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinance(int id, Finance finance)
        {
            if (id != finance.Id)
            {
                return BadRequest();
            }

            _context.Entry(finance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanceExists(id))
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

       
        [HttpPost]
        public ActionResult<Finance> PostFinance([FromBody] FinanceCreateModel model)
        {
            // Validate the existence of the CustomerRequest
            var existingFinance = _context.Finance
                .FirstOrDefault(f => f.CustomerRequestId == model.CustomerRequestId);

            if (existingFinance != null)
            {
                // Handle as needed: return an error, update existing record, etc.
                return BadRequest(new { Message = "A finance record for this customer request already exists." });
            }

            var customerRequest = _context.CustomerRequests
                .FirstOrDefault(cr => cr.Id == model.CustomerRequestId);
            if (customerRequest == null)
            {
                return NotFound(new { Message = "Customer request not found." });
            }

            var finance = new Finance
            {
                Amount = model.Amount,
                TermInMonths = model.TermInMonths,
                RepaymentAmount = model.RepaymentAmount,
                RepaymentFrequency = model.RepaymentFrequency,
                CustomerRequestId = model.CustomerRequestId
            };

            _context.Finance.Add(finance);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetFinance), new { id = finance.Id }, finance);
        }


        // DELETE: api/Finances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinance(int id)
        {
            var finance = await _context.Finance.FindAsync(id);
            if (finance == null)
            {
                return NotFound();
            }

            _context.Finance.Remove(finance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinanceExists(int id)
        {
            return _context.Finance.Any(e => e.Id == id);
        }
    }
}
