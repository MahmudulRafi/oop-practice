using Practice_05.Models;

var creditCard = new CreditCard();

try
{
    creditCard.PayBill(50000);

    creditCard.WithdrawCash(15000);

    creditCard.WithdrawCash(10000);

    creditCard.PayBill(20000);

    creditCard.WithdrawCash(10000);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

