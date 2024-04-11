using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodingChallengeMM.Server.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using CodingChallengeMM.Server.Interfaces;
using CodingChallengeMM.Server.Model.Entities;
using CodingChallengeMM.Server.Model.Dto;

namespace CodingChallengeMM.Server.Controllers
{
    /// <summary>
    ///  The customer requests controlller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRequestsController : ControllerBase
    {

        private readonly IEmailDomainService _emailDomainService;
        private string url = "https://www.google.com/";
        private readonly ApplicationDbContext _context;

        /// <summary>
        ///  The customer request controller constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="emailDomainService"></param>
        public CustomerRequestsController(ApplicationDbContext context , IEmailDomainService emailDomainService)
        {
            _emailDomainService = emailDomainService;
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
        public ActionResult<string> PostCustomerRequest(CustomerRequestCreateModel request)
        {
            if (_emailDomainService.IsEmailDomainBlacklisted(request.Email))
            {
                return BadRequest(new { Message = "The email's domain is blacklisted and cannot be processed." });
            }
            var existingRequest = _context.CustomerRequests
                    .FirstOrDefault(cr => cr.FirstName == request.FirstName && cr.LastName == request.LastName && cr.DateOfBirth == request.DateOfBirth);

            if (existingRequest != null)
            {
                return Ok(url);
            }

            var customerRequest = new CustomerRequest
            {
                AmountRequired = request.AmountRequired,
                Term = request.Term,
                Title = request.Title,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Mobile = request.Mobile,
                Email = request.Email
                // Id is auto-generated, so it's not set here
            };
           
            _context.CustomerRequests.Add(customerRequest);
            _context.SaveChanges();

            return Ok(url);
            //return CreatedAtAction("GetCustomerRequest", new { id = customerRequest.Id }, customerRequest);
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
