"use strict";
// CreditCardPayment implements both Payment & Refundable
class CreditCardPayment {
    amount;
    constructor(amount) {
        this.amount = amount;
    }
    pay() {
        console.log(`Paid ${this.amount} using Credit Card`);
    }
    refund() {
        console.log("Refund initiated to Credit Card");
    }
}
// UPIPayment implements only Payment
class UPIPayment {
    amount;
    constructor(amount) {
        this.amount = amount;
    }
    pay() {
        console.log(`Paid ${this.amount} using UPI`);
    }
}
const creditPayment = new CreditCardPayment(1000);
creditPayment.pay();
creditPayment.refund();
const upiPayment = new UPIPayment(500);
upiPayment.pay();
