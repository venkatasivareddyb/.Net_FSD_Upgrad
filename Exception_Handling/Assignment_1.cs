namespace Exception_Handling
{
    using System;

    // Custom Exception
    public class CheckBalanceException : Exception
    {
        public CheckBalanceException(string message) : base(message) { }
    }

    public class BankAccount
    {
        public int AccountNumber { get; }
        public string Name { get; }
        public static double Balance { get; private set; } = 500; // minimum balance
        public string TransactionType { get; }
        public double TransactionAmount { get; }

        public BankAccount(int accountNumber, string name, string transactionType, double transactionAmount)
        {
            AccountNumber = accountNumber;
            Name = name;
            TransactionType = transactionType;
            TransactionAmount = transactionAmount;
        }

        public void PerformTransaction()
        {
            if (TransactionType.ToLower() == "d") // deposit
            {
                Balance += TransactionAmount;
                Console.WriteLine($"Deposited: {TransactionAmount}, New Balance: {Balance}");
            }
            else if (TransactionType.ToLower() == "c") // credit/withdraw
            {
                if (Balance - TransactionAmount < 500)
                {
                    throw new CheckBalanceException("Balance cannot go below minimum limit of 500!");
                }
                else
                {
                    Balance -= TransactionAmount;
                    Console.WriteLine($"Withdrawn: {TransactionAmount}, New Balance: {Balance}");
                }
            }
            else
            {
                Console.WriteLine("Invalid transaction type!");
            }
        }
    }

    class Assignment_1
    {
        static void Main()
        {
            try
            {
                BankAccount acc1 = new BankAccount(101, "Ravi", "d", 2000);
                acc1.PerformTransaction();

                BankAccount acc2 = new BankAccount(102, "Priya", "c", 1800);
                acc2.PerformTransaction();
            }
            catch (CheckBalanceException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
