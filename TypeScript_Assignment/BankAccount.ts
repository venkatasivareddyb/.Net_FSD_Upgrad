class BankAccount {
    depositorName: string;
    accountNumber: string;
    accountType: string;
    balance: number;

    constructor(name: string, accNo: string, type: string, balance: number) {
        this.depositorName = name;
        this.accountNumber = accNo;
        this.accountType = type;
        this.balance = balance;
    }

    deposit(amount: number): void {
        this.balance += amount;
        console.log(`Deposited ₹${amount}. New Balance: ₹${this.balance}`);
    }

    withdraw(amount: number): void {
        if (amount <= this.balance) {
            this.balance -= amount;
            console.log(`Withdrawn ₹${amount}. Remaining Balance: ₹${this.balance}`);
        } else {
            console.log("Insufficient Balance!");
        }
    }

    display(): void {
        console.log(`Depositor: ${this.depositorName}, Balance: ₹${this.balance}`);
    }
}

const acc1 = new BankAccount("Alice", "ACC123", "Savings", 1000);
acc1.deposit(500);
acc1.withdraw(300);
acc1.display();
