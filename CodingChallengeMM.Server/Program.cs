using CodingChallengeMM.Server.Data;
using CodingChallengeMM.Server.Factories;
using CodingChallengeMM.Server.Interfaces;
using CodingChallengeMM.Server.Services;
using CodingChallengeMM.Server.Strategies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddScoped<IEmailDomainService, EmailDomainService>();
builder.Services.AddScoped<IMobileNumberBlacklistService, MobileNumberBlacklistService>();
builder.Services.AddScoped<ILoanProductStrategyFactory, LoanProductStrategyFactory>();
builder.Services.AddScoped<ProductAStrategy>();
builder.Services.AddScoped<ProductBStrategy>();
builder.Services.AddScoped<ProductCStrategy>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseCors(x =>
{
    x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
