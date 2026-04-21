"use strict";
class BankAccount {
    depositorName;
    accountNumber;
    accountType;
    balance;
    constructor(name, accNo, type, balance) {
        this.depositorName = name;
        this.accountNumber = accNo;
        this.accountType = type;
        this.balance = balance;
    }
    deposit(amount) {
        this.balance += amount;
        console.log(`Deposited ₹${amount}. New Balance: ₹${this.balance}`);
    }
    withdraw(amount) {
        if (amount <= this.balance) {
            this.balance -= amount;
            console.log(`Withdrawn ₹${amount}. Remaining Balance: ₹${this.balance}`);
        }
        else {
            console.log("Insufficient Balance!");
        }
    }
    display() {
        console.log(`Depositor: ${this.depositorName}, Balance: ₹${this.balance}`);
    }
}
const acc1 = new BankAccount("Alice", "ACC123", "Savings", 1000);
acc1.deposit(500);
acc1.withdraw(300);
acc1.display();
