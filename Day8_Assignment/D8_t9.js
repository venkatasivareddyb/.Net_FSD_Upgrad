class Product {
  constructor({ name, price, category = "General" }) {
    this.name = name;
    this.price = price;
    this.category = category;
  }

  showInfo = () => {
    const { name, price, category } = this;
    console.log(`Product: ${name}, Price: ${price}, Category: ${category}`);
  }
}

let product = new Product({ name: "Laptop", price: 50000 });
product.showInfo();