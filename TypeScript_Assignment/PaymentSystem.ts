// Payment interface
interface Payment {
    amount: number;
    pay(): void;
}

// Refundable interface
interface Refundable {
    refund(): void;
}

// CreditCardPayment implements both Payment & Refundable
class CreditCardPayment implements Payment, Refundable {
    amount: number;

    constructor(amount: number) {
        this.amount = amount;
    }

    pay(): void {
        console.log(`Paid ${this.amount} using Credit Card`);
    }

    refund(): void {
        console.log("Refund initiated to Credit Card");
    }
}

// UPIPayment implements only Payment
class UPIPayment implements Payment {
    amount: number;

    constructor(amount: number) {
        this.amount = amount;
    }

    pay(): void {
        console.log(`Paid ${this.amount} using UPI`);
    }
}
const creditPayment = new CreditCardPayment(1000);
creditPayment.pay();
creditPayment.refund();

const upiPayment = new UPIPayment(500);
upiPayment.pay();
