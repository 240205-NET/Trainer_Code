namespace Banking
{
    class Transaction
    {
        // Fields
        public double amount;
        public string note;
        public DateTime date;
        public int transactionId;

        private static int transactionIdSeed = 1234;

        // Constructor
        public Transaction(double amount, DateTime date, string note = "")
        {
            this.amount = amount;
            this.date = date;
            this.note = note;
            this.transactionId = transactionIdSeed;
            transactionIdSeed++;
        }

        // Methods
    }
}