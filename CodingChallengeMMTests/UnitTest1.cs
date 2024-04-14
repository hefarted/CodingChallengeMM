using CodingChallengeMM.Server.Controllers;
using CodingChallengeMM.Server.Data;
using CodingChallengeMM.Server.Interfaces;
using CodingChallengeMM.Server.Model.Dto;
using CodingChallengeMM.Server.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;

namespace CodingChallengeMMTests
{
    public class CustomerRequestsControllerTests
    {
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly Mock<IEmailDomainService> _mockEmailDomainService;
        private readonly CustomerRequestsController _controller;
        private readonly string _testUrl = "https://localhost:4200/quote-calculator";

        public CustomerRequestsControllerTests()
        {
            _mockContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            _mockEmailDomainService = new Mock<IEmailDomainService>();
            _controller = new CustomerRequestsController(_mockContext.Object, _mockEmailDomainService.Object);
        }

        [Fact]
        public void PostCustomerRequest_ReturnsCreatedResponse_WhenRequestIsValid()
        {
            // Arrange
            var requestModel = new CustomerRequestCreateModel
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com",
                // Other properties as needed
            };

            _mockEmailDomainService.Setup(service => service.IsEmailDomainBlacklisted(requestModel.Email))
                                   .Returns(false);

            // Simulate that there is no existing customer request with the same first name, last name, and date of birth
            _mockContext.Setup(context => context.CustomerRequests)
                        .Returns(Mock.Of<DbSet<CustomerRequest>>());

            // Act
            var result =  _controller.PostCustomerRequest(requestModel);

            // Assert
            var createdAtActionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status201Created, createdAtActionResult.StatusCode);

            var responseValue = Assert.IsType<Dictionary<string, object>>(createdAtActionResult.Value);
            Assert.True((bool)responseValue["success"]);
            Assert.NotNull(responseValue["url"]);
        }

        // Add more tests for different scenarios like blacklisted email domain, existing customer request, and exceptions


    }
}