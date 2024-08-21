using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using StrategyBank.Application.Services;
using StrategyBank.Core.Repositories;
using StrategyBank.Core.Strategies;
using StrategyBank.Core.Strategies.Interfaces;
using StrategyBank.Infrastructure.Data;
using StrategyBank.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TransactionDbContext>(options =>
    options.UseInMemoryDatabase("TransactionDB"));

// Services
builder.Services.AddScoped<TransactionService>();

// Repositories
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// Strategies
builder.Services.AddScoped<ITransactionStrategy, ArgentinaTransactionStrategy>();
builder.Services.AddScoped<ITransactionStrategy, BrazilToAsiaStrategy>();
builder.Services.AddScoped<ITransactionStrategy, BrazilToChinaStrategy>();
builder.Services.AddScoped<ITransactionStrategy, BrazilToBrazilStrategy>();
builder.Services.AddScoped<ITransactionStrategy, BrazilToEnglandStrategy>();
builder.Services.AddScoped<ITransactionStrategy, BrazilToEuropeStrategy>();
builder.Services.AddScoped<ITransactionStrategy, BrazilToPortugalStrategy>();
builder.Services.AddScoped<ITransactionStrategy, ForeignToBrazilStrategy>();
builder.Services.AddScoped<ITransactionStrategy, ForeignToForeignStrategy>();
builder.Services.AddScoped<ITransactionStrategy, DefaultStrategy>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
