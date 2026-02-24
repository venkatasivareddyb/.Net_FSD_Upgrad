let books = [
  { id: 1, title: "JavaScript Basics", price: 450, stock: 10 },
  { id: 2, title: "React Guide", price: 650, stock: 5 },
  { id: 3, title: "Node.js Mastery", price: 550, stock: 8 },
  { id: 4, title: "CSS Complete", price: 300, stock: 12 }
];

console.log(books.map(b => b.title));

console.log(books.reduce((sum, b) => sum + b.price * b.stock, 0));

console.log(books.filter(b => b.price > 500));
books = books.map(b => ({...b, price: b.price * 1.05}));
console.log(books.sort((a, b) => a.price - b.price));
books = books.filter(b => b.id !== 2);
console.log(books.some(b => b.stock === 0));