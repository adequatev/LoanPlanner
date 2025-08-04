using LoanPlanner.Core.Models;
using LoanPlanner.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanPlanner.Web.Controllers;

/// <summary>
/// rest-api template just in case
/// </summary>

[Route("api/loans")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly DailyLoanCalculationService _dailyLoanCalculationService;
    private readonly LoanCalculationService _loanCalculationService;
    private readonly ILogger<ValuesController> _logger;

    public ValuesController(
        LoanCalculationService loanCalculationService,
        DailyLoanCalculationService dailyLoanCalculationService,
        ILoggerFactory loggerFactory)
    {
        _loanCalculationService = loanCalculationService;
        _dailyLoanCalculationService = dailyLoanCalculationService;
        _logger = loggerFactory.CreateLogger<ValuesController>();
    }


    [HttpPost("calc")]
    public IActionResult CalculateLoans([FromBody] LoanInput loanInput)
    {
        /// services
        return Ok();
    }


}
