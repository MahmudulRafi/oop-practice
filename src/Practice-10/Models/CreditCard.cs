namespace Practice_10.Models
{
    public class CreditCard
    {
        private const double CreditLimit = 500000;
        public long CardNo { get; private set; }
        public int Cvv { get; private set; }
        public DateTime ExpiryDate { get; private set; }

        private double _usedBalance;

        public double OutstandingBalance => CreditLimit - _usedBalance;
        public bool IsCardValid => DateTime.Now.Date <= ExpiryDate.Date;

        public CreditCard(long cardNo, int cvv, DateTime expiryDate)
        {
            CardNo = cardNo;
            Cvv = cvv;
            ExpiryDate = expiryDate;
        }

        public void WithdrawMoney(double amount)
        {
            if (!IsCardValid)
                throw new InvalidOperationException("Credit card is expired");

            if (amount <= 0)
                throw new InvalidOperationException("Amount can't be negative or zero");

            var deducatableAmount = _usedBalance + amount;

            if (deducatableAmount > CreditLimit)
                throw new InvalidOperationException("Can't deduct more than available balance");

            _usedBalance += amount;
        }
    }
}
