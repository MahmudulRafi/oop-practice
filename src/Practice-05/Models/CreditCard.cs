namespace Practice_05.Models
{
    public class CreditCard
    {
        private const double MaximumCreditLimit = 500000;
        private const double MaximumDailyWithdrawalLimit = 100000;
        private const double MaximumPerTransactionWithdrawalLimit = 20000;

        private double _totalSpentAmount;
        private double _dailyWithdrawalAmount;
        private DateTime _lastTransactionDate;

        public double AvailableBalance => MaximumCreditLimit - _totalSpentAmount;
        public double TotalSpent => _totalSpentAmount;
        public double DailyWithdrawalUsed => IsToday(_lastTransactionDate) ? _dailyWithdrawalAmount : 0;
        public double RemainingDailyWithdrawalLimit => MaximumDailyWithdrawalLimit - DailyWithdrawalUsed;

        public void WithdrawCash(double amount)
        {
            ValidateAmount(amount);
            ValidateWithdrawalLimits(amount);
            ValidateCreditLimit(amount);

            ProcessWithdrawal(amount);
        }

        public void PayBill(double amount)
        {
            ValidateAmount(amount);
            ValidateCreditLimit(amount);

            ProcessTransaction(amount);
        }

        private static void ValidateAmount(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"The amount must be greater than zero.", nameof(amount));
            }
        }

        private void ValidateWithdrawalLimits(double amount)
        {
            if (amount > MaximumPerTransactionWithdrawalLimit)
            {
                throw new InvalidOperationException(
                    $"Withdrawal amount of {amount} exceeds the maximum per-transaction limit of {MaximumPerTransactionWithdrawalLimit}.");
            }

            var currentDailyWithdrawal = IsToday(_lastTransactionDate) ? _dailyWithdrawalAmount : 0;

            if (currentDailyWithdrawal + amount > MaximumDailyWithdrawalLimit)
            {
                var remainingDaily = MaximumDailyWithdrawalLimit - currentDailyWithdrawal;
                throw new InvalidOperationException(
                    $"Withdrawal amount of {amount} exceeds the remaining daily limit of {remainingDaily}.");
            }
        }

        private void ValidateCreditLimit(double amount)
        {
            if (_totalSpentAmount + amount > MaximumCreditLimit)
            {
                var availableCredit = MaximumCreditLimit - _totalSpentAmount;

                throw new InvalidOperationException(
                    $"Transaction amount of {amount} exceeds the available credit limit of {availableCredit}.");
            }
        }

        private void ProcessWithdrawal(double amount)
        {
            UpdateDailyWithdrawalAmount(amount);
            ProcessTransaction(amount);
        }

        private void ProcessTransaction(double amount)
        {
            _totalSpentAmount += amount;
            _lastTransactionDate = DateTime.Now;
        }

        private void UpdateDailyWithdrawalAmount(double amount)
        {
            _dailyWithdrawalAmount = IsToday(_lastTransactionDate)
                ? _dailyWithdrawalAmount + amount
                : amount;
        }

        private static bool IsToday(DateTime date)
        {
            return date.Date == DateTime.Now.Date;
        }
    }
}