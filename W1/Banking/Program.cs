using System;

namespace Banking
{
    class Program
    {
        public static void Main(string[] args)
        {
            Account firstAccount = new SavingsAccount("James", 1000);
            Account secondAccount = new SavingsAccount("Randall", 1000);
            Account thirdAccount = new SavingsAccount("Meryem", 1000);

            Console.WriteLine(firstAccount.DisplayBalance());
            Console.WriteLine(secondAccount.DisplayBalance());
            Console.WriteLine(thirdAccount.DisplayBalance());

            secondAccount.MakeDeposit(500);

            Console.WriteLine(secondAccount.DisplayBalance());

            Console.WriteLine(secondAccount.DisplayTransactionHistory());
        }

    }
}