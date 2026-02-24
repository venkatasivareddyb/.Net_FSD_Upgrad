let employees = [
 { id:1, name:"Ravi", dept:"IT", salary:70000 },
 { id:2, name:"Anita", dept:"HR", salary:50000 },
 { id:3, name:"Karan", dept:"IT", salary:80000 },
 { id:4, name:"Meena", dept:"Finance", salary:60000 }
];

console.log(employees.reduce((sum, e) => sum + e.salary, 0));
console.log(employees.reduce((max, e) => e.salary > max.salary ? e : max));
console.log(employees.reduce((min, e) => e.salary < min.salary ? e : min));
employees = employees.map(e => e.dept === "IT" ? {...e, salary: e.salary * 1.15} : e);
let grouped = employees.reduce((acc, e) => {
  acc[e.dept] = acc[e.dept] || [];
  acc[e.dept].push(e);
  return acc;
}, {});
for (let dept in grouped) {
  let avg = grouped[dept].reduce((sum, e) => sum + e.salary, 0) / grouped[dept].length;
  console.log(dept, avg);
}
console.log(employees.sort((a, b) => b.salary - a.salary));