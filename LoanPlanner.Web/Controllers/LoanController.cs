using LoanPlanner.Core.Models;
using LoanPlanner.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanPlanner.Web.Controllers;

[Route("[controller]")]
public class LoanController : BaseCalculationController
{
    private readonly LoanCalculationService _loanCalculationService;
    private readonly ILogger<LoanController> _logger;
    public LoanController(LoanCalculationService loanCalculationService, ILoggerFactory loggerFactory)
    {
        _loanCalculationService = loanCalculationService;
        _logger = loggerFactory.CreateLogger<LoanController>();
    }

    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogInformation("Index");

        return View("Index", new LoanInput());
    }

    [HttpPost]
    public async Task<IActionResult> Calculate(LoanInput input)
    {
        _logger.LogInformation("Calculate");

        return await ExecuteAsync(async () =>
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState was invalid");
                return View("Index", input);
            }
            
            // cpu bound operation so i decided to not put await here for now
            var schedule = _loanCalculationService.CalculateSchedule(
                input.Amount,
                input.Term,
                input.InterestRate
            );
            ViewBag.Schedule = schedule;

            return View("Result", input);
        });

    }

}
