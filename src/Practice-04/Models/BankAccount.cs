namespace Practice_04.Models
{
    public class BankAccount
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;

        private double _balance;
        
        public double GetBalance()
        {
            return _balance;
        }

        public void WithdrawMoney(double amount)
        {
            if (amount <= 0)
                throw new InvalidOperationException("Can't withdraw negative or zero amount");

            double balanceAfterDeduction = _balance - amount;

            if (balanceAfterDeduction < 0)
                throw new InvalidOperationException("Unable to withdraw negative or zero amount");

            _balance -= amount;
        }

        public void DepositMoney(double amount)
        {
            if (amount <= 0)
                throw new InvalidOperationException("Can't deposit negative or zero amount");

            _balance += amount;
        }

        public void TransferMoney(BankAccount bankAccount, double amount)
        {
            if (amount <= 0)
                throw new InvalidOperationException("Can't transfer negative or zero amount");

            double transferableAmount = _balance - amount;

            if (transferableAmount < 0)
                throw new InvalidOperationException("Unable to transfer negative or zero amount");

            bankAccount.DepositMoney(amount);

            _balance -= amount;
        }
    }
}
