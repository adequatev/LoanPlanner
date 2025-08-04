using LoanPlanner.Core.Services;

namespace LoanPlanner.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(10000, 360, 0.0332, 30, 9211, 888, 99)]
        public void Test1(decimal amount, int termDays, decimal dailyInterestRate, int paymentStepDays, int bln, int pmnt, int ntrst)
        {
            //Assume
            var dailyLoanService = new DailyLoanCalculationService();
            //Act
            var res = dailyLoanService
                .CalculateSchedule(amount, termDays, dailyInterestRate, paymentStepDays)
                .ToList();
            //Assert
            Assert.NotNull(res[^1]);
            Assert.Equal(bln, (int)res[0].Balance);
            Assert.Equal(pmnt, (int)res[0].Payment);
            Assert.Equal(ntrst, (int)res[0].Interest);
        }

        [Theory]
        [InlineData(10000, 12, 12, 9211, 888, 879, 0)]
        public void Test2(decimal amount, int termMonths, decimal interestRate, int bln1, int pmnt, int prn, int bln2)
        {
            var classicLoanService = new LoanCalculationService();

            var res = classicLoanService.CalculateSchedule(amount, termMonths, interestRate);

            Assert.Equal(bln1, (int)res[0].Balance);
            Assert.Equal(pmnt, (int)res[0].Payment);
            Assert.Equal(prn, (int)res[^1].Principal);
            Assert.Equal(bln2, (int)res[^1].Balance);

        }

        [Fact]
        public void Test3()
        {
            var dailyLoanService = new DailyLoanCalculationService();
            
            Assert.Throws<Exception>(() => dailyLoanService.CalculateSchedule(20000, 15, 1, 16));
        }
    }
}