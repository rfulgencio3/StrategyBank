using Microsoft.AspNetCore.Mvc;
using StrategyBank.Application.Models.InputModel;
using StrategyBank.Application.Services;
using TransactionProcessor.Core.Entities;

namespace StrategyBank.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly TransactionService _transactionService;

    public TransactionsController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost]
    public IActionResult ProcessTransaction([FromBody] TransactionInputModel inputModel)
    {
        try
        {
            var result = _transactionService.ProcessTransaction(inputModel);
            return Ok(result); 
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
