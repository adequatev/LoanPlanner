using System.ComponentModel.DataAnnotations;

namespace LoanPlanner.Core.Models;

public class DailyLoanInput
{
    [Required(ErrorMessage = "Сумма займа обязательна")]
    [Range(1000, 5000000, ErrorMessage = "Сумма должна быть между 1,000 и 5,000,000 руб.")]
    [Display(Name = "Сумма займа")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Срок займа обязателен")]
    [Range(1, 730, ErrorMessage = "Срок должен быть от 1 до 730 дней")]
    [Display(Name = "Срок займа")]
    public int Term { get; set; }

    [Required(ErrorMessage = "Процентная ставка обязательна")]
    [Range(0.0001, 5, ErrorMessage = "Ставка должна быть между 0.0001% и 5%")]
    [Display(Name = "Дневная процентная ставка")]
    public decimal InterestRate { get; set; }

    [Required(ErrorMessage = "Шаг платежа обязателен")]
    [Range(1, 183, ErrorMessage = "Шаг платежа должен быть от 1 до 183 дней")]
    [Display(Name = "Шаг платежа")]
    public int PaymentStep { get; set; }
}
