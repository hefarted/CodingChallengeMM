using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodingChallengeMM.Server.Data;
using CodingChallengeMM.Server.Interfaces;
using Azure.Core;
using CodingChallengeMM.Server.Model.Entities;
using CodingChallengeMM.Server.Model.Dto;
using CodingChallengeMM.Server.Utilities;
using CodingChallengeMM.Server.Model.Responses;
using CodingChallengeMM.Server.Services;
using System.Security.Policy;

namespace CodingChallengeMM.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FinancesController : ControllerBase
    {
        private readonly ILoanProductStrategyFactory _strategyFactory;
        private readonly IMobileNumberBlacklistService _mobileNumberBlacklistService;

        private readonly ApplicationDbContext _context;

        public FinancesController(ILoanProductStrategyFactory strategyFactory,
            IMobileNumberBlacklistService mobileNumberBlacklistService, ApplicationDbContext context)   
        {
            _mobileNumberBlacklistService = mobileNumberBlacklistService;
            _strategyFactory = strategyFactory;
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
        public IActionResult PostFinance(FinanceCreateModel model)
        {
            // Validate the existence of the CustomerRequest
            var existingFinance = _context.Finance
                .FirstOrDefault(f => f.CustomerRequestId == model.CustomerRequestId);

            // Check if email domain is blacklisted
            if (existingFinance != null)
            {
                var errorResponse = new ErrorResponse
                {
                    Success = false,
                    Error = new ErrorDetail
                    {
                        Code = "ExistingFinance",
                        Message = "A finance record for this customer request already exists."
                    }
                };
                return BadRequest(errorResponse);
            }

            var customerRequest = _context.CustomerRequests
                .FirstOrDefault(cr => cr.Id == model.CustomerRequestId);

            if (!AgeValidator.IsEighteenYearsOld(customerRequest.DateOfBirth))
            {
                var errorResponse = new ErrorResponse
                {
                    Success = false,
                    Error = new ErrorDetail
                    {
                        Code = "ExistingFinance",
                        Message = "The applicant must be at least 18 years old."
                    }
                };
                return BadRequest(errorResponse);
        
            }

            if (_mobileNumberBlacklistService.IsBlacklisted(customerRequest.Mobile))
            {
                var errorResponse = new ErrorResponse
                {
                    Success = false,
                    Error = new ErrorDetail
                    {
                        Code = "MobileBlackListed",
                        Message = "TThe mobile number is blacklisted."
                    }
                };
                return BadRequest(errorResponse);
            }

            
            var strategy = _strategyFactory.GetStrategy(model.ProductType);
            
            var totalAmount = strategy.CalculateFinanceAmount(customerRequest.AmountRequired , customerRequest.Term);

            if (customerRequest == null)
            {
                return NotFound(new { Message = "Customer request not found." });
            }

            var finance = new Finance
            {
                RepaymentAmount = totalAmount,
                RepaymentFrequency = model.RepaymentFrequency,
                CustomerRequestId = model.CustomerRequestId
            };

            _context.Finance.Add(finance);
            _context.SaveChanges();

            var newUrl = "https://localhost:4200/quote-summary";
            return Created(newUrl, new { success = true, id = finance.Id, url = newUrl + "/" + finance.Id });

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
