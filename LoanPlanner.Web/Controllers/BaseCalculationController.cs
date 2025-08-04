using Microsoft.AspNetCore.Mvc;

namespace LoanPlanner.Web.Controllers;

public class BaseCalculationController : Controller
{
    protected async Task<IActionResult> ExecuteAsync(Func<Task<IActionResult>> func)
    {
        try
        {
            return await func.Invoke();
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }
}
