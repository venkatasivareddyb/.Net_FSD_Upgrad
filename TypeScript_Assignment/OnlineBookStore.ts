class Book {
    isbn: string;
    bookName: string;
    bookTitle: string;
    bookAuthor: string;
    quantity: number;
    price: number;

    constructor(isbn: string, bookName: string, bookTitle: string, bookAuthor: string, quantity: number, price: number) {
        this.isbn = isbn;
        this.bookName = bookName;
        this.bookTitle = bookTitle;
        this.bookAuthor = bookAuthor;
        this.quantity = quantity;
        this.price = price;
    }

    displayDetails(): void {
        console.log(`ISBN: ${this.isbn}`);
        console.log(`Name: ${this.bookName}`);
        console.log(`Title: ${this.bookTitle}`);
        console.log(`Author: ${this.bookAuthor}`);
        console.log(`Quantity: ${this.quantity}`);
        console.log(`Price: ₹${this.price}`);
    }

    calculateBill(): number {
        return this.quantity * this.price;
    }
}


const book1 = new Book("12345", "TS Basics", "Learn TypeScript", "John Doe", 3, 500);
book1.displayDetails();
console.log("Bill Amount: ₹" + book1.calculateBill());
