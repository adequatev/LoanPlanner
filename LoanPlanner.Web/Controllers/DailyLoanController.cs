using LoanPlanner.Core.Models;
using LoanPlanner.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoanPlanner.Web.Controllers;

[Route("[controller]")]
public class DailyLoanController : BaseCalculationController
{
    private readonly DailyLoanCalculationService _dailyLoanCalculationService;
    private readonly ILogger<DailyLoanController> _logger;
    public DailyLoanController(DailyLoanCalculationService dailyLoanCalculationService, ILoggerFactory loggerFactory)
    {
        _dailyLoanCalculationService = dailyLoanCalculationService;
        _logger = loggerFactory.CreateLogger<DailyLoanController>();
    }

    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogInformation("Index");

        return View("Index", new DailyLoanInput());
    }

    [HttpPost]
    public async Task<IActionResult> Calculate(DailyLoanInput input)
    {
        _logger.LogInformation("Calculate");
        return await ExecuteAsync(async () =>
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState was invalid");
                return View("Index", input);
            }

            var schedule = _dailyLoanCalculationService.CalculateSchedule(
                input.Amount,
                input.Term,
                input.InterestRate,
                input.PaymentStep
            ).ToList();
            ViewBag.Schedule = schedule;

            return View("Result", input);
        });
    }

}

