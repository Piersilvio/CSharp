
/*
 * Program.cs
 * contiene il metodo Main
 * 
 */

using MySuperBank.it.alten.com.entity;

var account = new BankAccount("Piersilvio Spicoli", 10000);
Console.WriteLine($"\nAccount {account.getNumber()} was created by {account.getOnwer()} \nwith balance {account.getBalance()}");

account.makeWithDrawal(120, DateTime.Now, "Hammock");
Console.WriteLine($"\nbilancio generale: {account.getBalance()}");

account.makeWithDrawal(650, DateTime.Now, "Xbox serie X");
Console.WriteLine($"\nbilancio generale: {account.getBalance()}");
Console.WriteLine("\n");
Console.WriteLine(account.getAccountHistory());