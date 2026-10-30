using System;
using System.Collections.Generic;
using System.Text;

namespace Home10EVENT
{
    public delegate void CardHandler(string message);
    public class CreditCard
    {
        public CreditCard(string number, string ownerFullName, string expiryDate, string pin, decimal creditLimit, decimal balance, decimal targetAmount)
        {
            Number = number;
            OwnerFullName = ownerFullName;
            ExpiryDate = expiryDate;
            this.pin = pin;
            CreditLimit = creditLimit;
            Balance = balance;
            this.targetAmount = targetAmount;
        }
        public string Number { get; set; }
        public string OwnerFullName { get; set; }
        public string ExpiryDate { get; set; }
        private string pin; 
        public decimal CreditLimit { get; set; }
        public decimal Balance { get; private set; }
        private decimal targetAmount; 

        public event CardHandler TopUpEvent;                 
        public event CardHandler WithdrawEvent;               
        public event CardHandler CreditStartedEvent;        
        public event CardHandler TargetAmountReachedEvent;    
        public event CardHandler PinChangedEvent;
        public void TopUp(decimal amount)
        {
            if (amount <= 0)
                throw new InvalidOperationException("Amount must be greater than zero");
            Balance += amount;
            TopUpEvent?.Invoke($"Account topped up by {amount}.Current balance: {Balance}"); 
            if (Balance >= targetAmount) 
            {
                TargetAmountReachedEvent?.Invoke($"Target amount reached");
            }
        }
        public void Withdraw(decimal amount, string enteredPin)
        {
            if (enteredPin != pin)
                throw new ArgumentException("Incorrect PIN code");
            if (amount <= 0)
                throw new InvalidOperationException("Withdrawal amount must be greater than zero");
            bool wasUsingCreditBefore = Balance < 0; 
            decimal totalAvailable = Balance + CreditLimit; 
            if (amount > totalAvailable)
            {
                throw new InvalidOperationException("Insufficient funds on the account");
            }
            Balance -= amount; 
            WithdrawEvent?.Invoke($"Withdrawn {amount}. Current balance: {Balance}"); 
            if (!wasUsingCreditBefore && Balance < 0) 
            {
                CreditStartedEvent?.Invoke($"Started using credit funds"); 
            }
        }
        public void ChangePin(string oldPin, string newPin)
        {
            if (oldPin != pin)
            {
                throw new ArgumentException("Incorrect old PIN code");
            }
            if (string.IsNullOrEmpty(newPin) || newPin.Length < 4)
            {
                throw new ArgumentException("New PIN code must contain at least 4 characters");
            }
            pin = newPin;
            PinChangedEvent?.Invoke("PIN code successfully changed");
        }
    }
}
