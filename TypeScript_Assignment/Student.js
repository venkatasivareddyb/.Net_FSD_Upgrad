"use strict";
class Student {
    rollNo;
    studName;
    marksEng;
    marksMaths;
    marksScience;
    constructor(rollNo, name, eng, maths, science) {
        this.rollNo = rollNo;
        this.studName = name;
        this.marksEng = eng;
        this.marksMaths = maths;
        this.marksScience = science;
    }
    displayResult() {
        const total = this.marksEng + this.marksMaths + this.marksScience;
        const percentage = (total / 300) * 100;
        console.log(`Student: ${this.studName}, Roll No: ${this.rollNo}`);
        console.log(`Total Marks: ${total}`);
        console.log(`Percentage: ${percentage.toFixed(2)}%`);
    }
}
const stud1 = new Student(101, "Bob", 80, 90, 85);
stud1.displayResult();
