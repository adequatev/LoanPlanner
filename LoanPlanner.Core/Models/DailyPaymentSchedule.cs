namespace LoanPlanner.Core.Models;

public class DailyPaymentSchedule
{
    public int PaymentNumber { get; set; }
    public int Day { get; set; }
    public decimal Payment { get; set; }
    public decimal Principal { get; set; }
    public decimal Interest { get; set; }
    public decimal Balance { get; set; }
}
