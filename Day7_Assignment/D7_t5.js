let numbers = [10, 20, 30, 10, 40, 20, 50, 60, 60];

console.log([...new Set(numbers)]);
let sorted = [...new Set(numbers)].sort((a, b) => b - a);
console.log(sorted[1]);
let freq = numbers.reduce((acc, n) => {
  acc[n] = (acc[n] || 0) + 1;
  return acc;
}, {});
console.log(freq);
console.log(numbers.find(n => freq[n] === 1));
console.log([...numbers.slice(2), ...numbers.slice(0,2)]);
let nested = [1,2,[3,4,[5]]];
console.log(nested.flat(Infinity));
let arr = [1,2,3,5,6];
let missing = Array.from({length:6}, (_,i)=>i+1).find(n => !arr.includes(n));
console.log(missing);