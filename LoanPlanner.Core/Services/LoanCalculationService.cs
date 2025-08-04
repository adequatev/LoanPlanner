using LoanPlanner.Core.Models;

namespace LoanPlanner.Core.Services;

public class LoanCalculationService
{
    /// <summary>
    /// Расчет аннуитетных займов
    /// </summary>
    /// <param name="amount">Сумма займа в рублях</param>
    /// <param name="termMonths">Срок займа в месяцах</param>
    /// <param name="interestRate">Ставка годовая в процентах</param>
    /// <returns>Список платежей</returns>
    public List<PaymentSchedule> CalculateSchedule(decimal amount, int termMonths, decimal interestRate)
    {
        var schedule = new List<PaymentSchedule>();
        decimal monthlyRate_i = interestRate / 100 / 12;

        var pow = (decimal)Math.Pow(1 + (double)monthlyRate_i, termMonths);
        var coef_K = (monthlyRate_i * pow) / (pow - 1);

        decimal monthlyPayment = amount * coef_K;
        decimal balance = amount;

        for (int month = 1; month <= termMonths; month++)
        {
            decimal interest = balance * monthlyRate_i;
            decimal principal = monthlyPayment - interest;
            balance -= principal;

            schedule.Add(new PaymentSchedule
            {
                Month       = month,
                Payment     = Math.Round(monthlyPayment, 2),
                Principal   = Math.Round(principal, 2),
                Interest    = Math.Round(interest, 2),
                Balance     = Math.Round(balance, 2)
            });
        }

        return schedule;
    }
}
