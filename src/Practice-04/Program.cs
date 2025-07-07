using Practice_04.Models;

BankAccount myAccount = new BankAccount();
myAccount.AccountNumber = "1ABC";
myAccount.AccountName = "Mahmudul Rafi";

myAccount.DepositMoney(2000);
myAccount.WithdrawMoney(1000);

BankAccount otherAcount = new BankAccount();
otherAcount.AccountNumber = "2DEF";
otherAcount.AccountName = "Mahadi Rafat";

myAccount.TransferMoney(otherAcount, 500);

Console.WriteLine($"My account balance : {myAccount.GetBalance()}");
Console.WriteLine($"Other account balance : {otherAcount.GetBalance()}");