using System;

namespace BankAccountNS
{
    /// <summary> 
    /// Bank Account demo class. 
    /// </summary> 
    public class BankAccount
    {
        private string _customerName;
        private double _balance;
        private bool _frozen;

        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";

        private BankAccount()
        {
        }

        public BankAccount(string customerName, double balance)
        {
            _customerName = customerName;
            _balance = balance;
        }

        public string CustomerName
        {
            get { return _customerName; }
        }

        public double Balance
        {
            get { return _balance; }
        }

        public void Debit(double amount)
        {
            if (_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount > _balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, 
                    DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, 
                    DebitAmountLessThanZeroMessage);
            }

            _balance -= amount;
        }

        public void Credit(double amount)
        {
            if (_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            _balance += amount;
        }

        private void FreezeAccount()
        {
            _frozen = true;
        }

        private void UnfreezeAccount()
        {
            _frozen = false;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);

            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }
    }
}