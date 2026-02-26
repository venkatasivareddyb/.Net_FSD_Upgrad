class BankAccount {
    #balance;
    constructor(accountNumber, accountHolder, balance) {
        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this.#balance = balance;
    }
    deposit(amount) {
        this.#balance += amount;
        console.log(`Deposited ${amount}. New balance: ${this.#balance}`);
    }
    withdraw(amount) {
        if (amount > this.#balance) {
            console.log("Insufficient funds.");
        } else {
            this.#balance -= amount;
            console.log(`Withdrew ${amount}. New balance: ${this.#balance}`);
        }
    }
    showBalance() {
        console.log(`Account Number: ${this.accountNumber}, Account Holder: ${this.accountHolder}, Balance: ${this.#balance}`);
    }
}
const account1 = new BankAccount("123456789", "Alice", 1000);
account1.showBalance();
account1.deposit(500);
account1.withdraw(200);
account1.withdraw(1500);