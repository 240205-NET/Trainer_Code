namespace Banking
{
    abstract class Account
    {
    // fields (properties and state)
        // pin
        // account owner
        private string owner;
        // type (checking/savings)
        // account number 

        // transaction history
        // [access modifier] [modifier] [type] [name]
        // List<T> ListName
        private List<Transaction> transactions = new List<Transaction>();


        // Michael asked, so here you go...
        // account -> savings account
        // savings "is a " account
        // child "is a" parent
        // List<account> accounts = new List<savings>
        // works for direct inheritance, and Interfaces

        // now back to our regularly programmed class...

        
        // Access Modifiers
            // public
            // private - * default access modifier
            // protected
            // internal 

        
        //getter/setter - special methods that allow you to modify the value of a field
            // private int accountNumber 
            // public int getAccountNumber()
            // {
            //     return this.accountNumber;
            // }
            // public void setAccountNumber(int number)
            // {
            //     this.accountNumber = number;
            // }

        public int accountNumber { get; set; }

        // public void setAccountNumber( int number)
        // { 
        //     if (number == null)
        //     {
        //         throw new Exception(MessageProcessingHandler: "value cannot be null", paramName :nameof(ValueTask));
        //     }
        //     this.accountNumber = value;
        // }

        // balance
        protected double balance;

        private static int accountNumberSeed = 123;
        
    // constructor - a specific method that details how to make an Account object.
        public Account(string ownerName, double initialBalance)
        { 
            //create account num
            this.accountNumber = accountNumberSeed;
            accountNumberSeed++;

            this.owner = ownerName;
            MakeDeposit(initialBalance);
        }

        // Overloading - two methods with the same name, with two different functionalities
        public Account(string ownerName)
        { 
            //create account num
            this.accountNumber = accountNumberSeed;
            accountNumberSeed++;

            this.owner = ownerName;
            MakeDeposit(0);
        }

    // methods (behavior)

        // deposits
        public void MakeDeposit (double amount, string note = "")
        {
            if (amount <= 0)
            {
                Console.WriteLine("deposit may not be less than 0.");
            }
            else
            {
                balance += amount;
                Transaction deposit = new Transaction(amount, DateTime.Now, note);
                transactions.Add(deposit);
            }
        }

        // withdrawls
        public virtual void MakeWithdrawl (double amount, string note = "")
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawls may not be less than 0.");
            }
            else if (balance-amount < 0)
            {
                Console.WriteLine("Insuffiecient funds!");
            }
            else
            {
                balance -= amount;
                Transaction withdrawl = new Transaction(-(amount), DateTime.Now, note);
                transactions.Add(withdrawl);
            }
        }

        // abstract methods MUST be overridden by a derived class
        // virtual methods CAN be overridden by a derived class, but don't have to.

        // account balance
        public virtual string DisplayBalance()
        {
            string balanceString = "Account # " + this.accountNumber + " has a balance of: " + this.balance;
            return balanceString;
        }

        // display the transaction history
        public virtual string DisplayTransactionHistory()
        {
            var history = new System.Text.StringBuilder();

            history.AppendLine("Date\t\tAmount\t\tNote");// \n - new line  \t - tab-space

            foreach(Transaction item in transactions)
            {
                history.AppendLine($"{item.date.ToShortDateString()}\t{item.amount}\t{item.note}"); // \n
            }
            return history.ToString();
        }

        // associate with another account
        // transfer to other accounts
        // closing account (remove account info)
    }
}
