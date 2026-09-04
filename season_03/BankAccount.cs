using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Prog.session03
{
    public class BankAccount
    {
        private string accNumber;
        private string accOwner;
        private double balance;

        public BankAccount(string accNumber, string accOwner)
        {
            this.accNumber = accNumber;
            this.accOwner = accOwner;
            this.balance = 0.0;
        }

        public BankAccount(string accNumber, string accOwner, double balance)
            :this(accNumber, accOwner)
        {
           
            this.balance = 0;
        }

        public string AccNumber
        {
            get { return accNumber; }
            set { accNumber = value; }
        }

        public string AccOwner
        {
            get { return accOwner; }
            set {
                if (string.IsNullOrEmpty(value?.Trim()))
                {
                    throw new ArgumentException("Account owner cannot be empty.");
                }
                else
                {
                    accOwner = value;
                }
            }
        }

        public double Balance
        {
            get { return balance; }
            //set { balance = value; }
        }

        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.accNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is BankAccount otherAccount)
            {
                return this.accNumber == otherAccount.accNumber;
            }
            return false;
        }


        //Mo ta o dang chuoi cua doi tuong
        public override string ToString()
        {
            return $"Account Number: {accNumber}, Account Owner: {accOwner}, Balance: {balance}";
        }
    }

    public class BankAccountTest
    {
        public static void Main1(string[] args)
        {
            try
            {
                //BankAccount account = new BankAccount("12345", "");
                ////BankAccount account ;
                //account.AccOwner = "";

                //bool kq = account.Deposit(1000.0);

                //if (kq)
                //{
                //    Console.WriteLine("Deposit successful. New balance: " + account.Balance);
                //}
                //else
                //{
                //    Console.WriteLine("Deposit failed. Balance remains: " + account.Balance);
                //}

                //Console.WriteLine(account.AccNumber);
                //Console.WriteLine(account.AccOwner);
                //Console.WriteLine(account.Balance);


                BankAccount account2 = new BankAccount("12345", "Than Thi Det");
                BankAccount account3 = new BankAccount("12345", "Than Thi Det");
                Console.WriteLine(account2);
                Console.WriteLine(account3);

                if (account2.Equals(account3))
                {
                    Console.WriteLine("Chung la 1");
                }
                else
                {
                    Console.WriteLine("CHung khac nhau");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
