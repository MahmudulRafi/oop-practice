using Practice_10.Models;

var customer = new Customer(10001001, "Mahmudul Hasan Rafi", "rafi@gamil.com", "01010100", new DateTime(1999, 01, 01));

if (customer.IsEligibleForCreditCard)
{
    var creditCard = new CreditCard(456896049294, 890, DateTime.Now.AddYears(5));

    customer.AssignCreditCard(creditCard);
}

customer.CreditCard.WithdrawMoney(10000);

Console.WriteLine($"Customer Name : {customer.FullName} has outstanding credit card balance of {customer.CreditCard.OutstandingBalance}");