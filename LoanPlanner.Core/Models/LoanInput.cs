using System.ComponentModel.DataAnnotations;

namespace LoanPlanner.Core.Models;

public class LoanInput
{
    [Required(ErrorMessage = "Сумма займа обязательна")]
    [Range(1000, 10000000, ErrorMessage = "Сумма должна быть между 1,000 и 10,000,000 руб.")]
    [Display(Name = "Сумма займа")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Срок займа обязателен")]
    [Range(1, 420, ErrorMessage = "Срок должен быть от 1 до 420 месяцев")]
    [Display(Name = "Срок займа")]
    public int Term { get; set; }

    [Required(ErrorMessage = "Процентная ставка обязательна")]
    [Range(0.1, 100, ErrorMessage = "Ставка должна быть между 0.1% и 100%")]
    [Display(Name = "Процентная ставка")]
    public decimal InterestRate { get; set; }
}