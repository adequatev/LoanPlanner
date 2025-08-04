using LoanPlanner.Core.Models;

namespace LoanPlanner.Core.Services;

public class DailyLoanCalculationService
{
    /// <summary>
    /// Рассчитывает платежи с процентами за день
    /// </summary>
    /// <param name="amount">Сумма займа в рублях</param>
    /// <param name="termDays">Срок займа в днях</param>
    /// <param name="dailyInterestRate">Дневная ставка в процентах</param>
    /// <param name="paymentStepDays">Шаг платежа в днях</param>
    /// <returns>Список платежей</returns>
    public IEnumerable<DailyPaymentSchedule> CalculateSchedule(decimal amount, int termDays, decimal dailyInterestRate, int paymentStepDays)
    {
        if (paymentStepDays > termDays)
        {
            throw new Exception("step was higher than whole term");
        }

        var schedule = new List<DailyPaymentSchedule>();

        decimal stepRate_i = dailyInterestRate / 100 * paymentStepDays;
        int numberOfPayments = (int)Math.Ceiling((double)termDays / paymentStepDays);
        
        var pow = (decimal)Math.Pow(1 + (double)stepRate_i, numberOfPayments);
        var coef_K = (stepRate_i * pow) / (pow - 1);
        
        decimal stepPayment = amount * coef_K;
        decimal balance = amount;
        int currentDay = 0;

        for (int paymentNumber = 1; paymentNumber <= numberOfPayments; ++paymentNumber)
        {
            currentDay += paymentStepDays;
            if (currentDay > termDays) currentDay = termDays;

            decimal interest = balance * stepRate_i;
            decimal principal = stepPayment - interest;
            balance -= principal;
            if (balance <= 0.01m) break;

            schedule.Add(new DailyPaymentSchedule
            {
                PaymentNumber   = paymentNumber,
                Day             = currentDay,
                Payment         = Math.Round(stepPayment, 2),
                Principal       = Math.Round(principal, 2),
                Interest        = Math.Round(interest, 2),
                Balance         = Math.Round(balance, 2)
            });

        }

        return schedule;
    }
}
