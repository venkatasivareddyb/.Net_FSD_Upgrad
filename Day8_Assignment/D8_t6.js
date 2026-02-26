class Shape {
  calculateArea() {}
}

class Circle extends Shape {
  constructor(radius) {
    super();
    this.radius = radius;
  }
  calculateArea() {
    console.log(`Circle Area: ${Math.PI * this.radius * this.radius}`);
  }
}

class Rectangle extends Shape {
  constructor(width, height) {
    super();
    this.width = width;
    this.height = height;
  }
  calculateArea() {
    console.log(`Rectangle Area: ${this.width * this.height}`);
  }
}

class Triangle extends Shape {
  constructor(base, height) {
    super();
    this.base = base;
    this.height = height;
  }
  calculateArea() {
    console.log(`Triangle Area: ${(this.base * this.height) / 2}`);
  }
}

let shapes = [new Circle(5), new Rectangle(4, 6), new Triangle(3, 7)];
shapes.forEach(s => s.calculateArea());