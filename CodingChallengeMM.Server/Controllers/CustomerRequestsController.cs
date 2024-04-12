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
using CodingChallengeMM.Server.Model.Responses;

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
        public readonly string url = "https://localhost:4200/quote-calculator";
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

        //// POST: api/CustomerRequests
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public ActionResult<string> PostCustomerRequest(CustomerRequestCreateModel request)
        //{
        //    if (_emailDomainService.IsEmailDomainBlacklisted(request.Email))
        //    {
        //        return BadRequest(new { Message = "The email's domain is blacklisted and cannot be processed." });
        //    }
        //    var existingRequest = _context.CustomerRequests
        //            .FirstOrDefault(cr => cr.FirstName == request.FirstName && cr.LastName == request.LastName && cr.DateOfBirth == request.DateOfBirth);

        //    if (existingRequest != null)
        //    {
        //        return Ok(url);
        //    }

        //    var customerRequest = new CustomerRequest
        //    {
        //        AmountRequired = request.AmountRequired,
        //        Term = request.Term,
        //        Title = request.Title,
        //        FirstName = request.FirstName,
        //        LastName = request.LastName,
        //        DateOfBirth = request.DateOfBirth,
        //        Mobile = request.Mobile,
        //        Email = request.Email
        //        // Id is auto-generated, so it's not set here
        //    };

        //    _context.CustomerRequests.Add(customerRequest);
        //    _context.SaveChanges();

        //    return Ok(url);
        //    //return CreatedAtAction("GetCustomerRequest", new { id = customerRequest.Id }, customerRequest);
        //}


        [HttpPost]
        public IActionResult PostCustomerRequest(CustomerRequestCreateModel request)
        {
            try
            {
                // Check if email domain is blacklisted
                if (_emailDomainService.IsEmailDomainBlacklisted(request.Email))
                {
                    var errorResponse = new ErrorResponse
                    {
                        Success = false,
                        Error = new ErrorDetail
                        {
                            Code = "EmailDomainBlacklisted",
                            Message = "The email's domain is blacklisted and cannot be processed."
                        }
                    };
                    return BadRequest(errorResponse);
                }

                // Check if a similar request already exists
                var existingRequest = _context.CustomerRequests
                    .FirstOrDefault(cr => cr.FirstName == request.FirstName && cr.LastName == request.LastName && cr.DateOfBirth == request.DateOfBirth);

                if (existingRequest != null)
                {
                    var existingUrl = Url.Link("GetCustomerRequest", new { id = existingRequest.Id });
                    return Ok(new { success = true, id = existingRequest.Id, url = existingUrl });
                }

                // Create a new customer request
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

                var newUrl = url;
                return Created(newUrl, new { success = true, id = customerRequest.Id, url = newUrl+"/"+customerRequest.Id });
            }
            catch (Exception ex)
            {
                // Log the exception and return an internal server error response
                var internalServerErrorResponse = new ErrorResponse
                {
                    Success = false,
                    Error = new ErrorDetail
                    {
                        Code = "InternalServerError",
                        Message = "An unexpected error occurred. Please try again later."
                    }
                };
                return StatusCode(StatusCodes.Status500InternalServerError, internalServerErrorResponse);
            }
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
