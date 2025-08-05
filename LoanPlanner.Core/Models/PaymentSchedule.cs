﻿namespace LoanPlanner.Core.Models;

public class PaymentSchedule
{
    public int Month { get; set; }
    public decimal Payment { get; set; }
    public decimal Principal { get; set; }
    public decimal Interest { get; set; }
    public decimal Balance { get; set; }
}