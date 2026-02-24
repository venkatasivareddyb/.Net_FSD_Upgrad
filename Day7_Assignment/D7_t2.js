let students = [
  { name: "Akhil", marks: 85 },
  { name: "Priya", marks: 72 },
  { name: "Ravi", marks: 90 },
  { name: "Meena", marks: 45 },
  { name: "Karan", marks: 30 }
];

console.log(students.filter(s => s.marks >= 40));
console.log(students.filter(s => s.marks >= 85));
console.log(students.reduce((sum, s) => sum + s.marks, 0) / students.length);
console.log(students.reduce((top, s) => s.marks > top.marks ? s : top));
console.log(students.filter(s => s.marks < 40).length);
students = students.map(s => ({
  ...s,
  grade: s.marks >= 85 ? "A" : s.marks >= 60 ? "B" : s.marks >= 40 ? "C" : "Fail"
}));