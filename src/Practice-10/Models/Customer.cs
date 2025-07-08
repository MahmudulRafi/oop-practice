namespace Practice_10.Models
{
    public class Customer
    {
        private const int CreditCardEligibleAge = 18;
        private CreditCard? _creditCard;
        public long AccountNo { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string MobileNo { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public CreditCard CreditCard => _creditCard ?? throw new InvalidOperationException("Customer does not have a credit card assigned.");
        public bool IsEligibleForCreditCard => (DateTime.Now.Year - DateOfBirth.Year) >= CreditCardEligibleAge;

        public Customer(long accountNo, string fullName, string email, string mobileNo, DateTime dateOfBirth)
        {
            AccountNo = accountNo;
            FullName = fullName;
            Email = email;
            MobileNo = mobileNo;
            DateOfBirth = dateOfBirth;
        }

        public void AssignCreditCard(CreditCard creditCard)
        {
            if (creditCard is null)
                throw new ArgumentNullException(nameof(creditCard), "Credit card can't be null");

            _creditCard = creditCard;
        }
    }
}
