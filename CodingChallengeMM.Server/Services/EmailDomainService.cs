﻿using CodingChallengeMM.Server.Data;
using CodingChallengeMM.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodingChallengeMM.Server.Services
{
    public class EmailDomainService : IEmailDomainService
    {
        private readonly ApplicationDbContext _context;

        public EmailDomainService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsEmailDomainBlacklisted(string email)
        {
            var domain = email.Split('@').LastOrDefault()?.ToLower();
            // Ensure the domain variable is not null before proceeding with the query
            if (domain == null) return false;

            // Use ToLower() for case-insensitive comparison
            return _context.BlacklistedDomains.Any(b => b.Domain.ToLower() == domain);
        }

    }

}
