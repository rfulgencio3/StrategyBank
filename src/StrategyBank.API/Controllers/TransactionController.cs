using Microsoft.AspNetCore.Mvc;
using StrategyBank.Application.Models.InputModel;
using StrategyBank.Application.UseCases;

namespace StrategyBank.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly TransactionFeeUseCase _useCase;

    public TransactionsController(TransactionFeeUseCase transactionService)
    {
        _useCase = transactionService;
    }

    [HttpPost]
    public IActionResult ProcessTransaction([FromBody] TransactionInputModel inputModel)
    {
        try
        {
            var result = _useCase.ProcessTransaction(inputModel);
            return Ok(result); 
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
