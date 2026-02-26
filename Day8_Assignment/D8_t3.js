class Student {
    constructor(name, marks){
        this.name = name;
        this.marks = [];
    }
    addMarks(...marks){
        this.marks.push(...marks);
    }
    calculateAverage(){
        const total = this.marks.reduce((acc, mark) => acc + mark, 0);
        return total / this.marks.length;
    }
    displayGrade(){
        const average = this.calculateAverage();
        let grade;
        if (average >= 90) {
            grade = 'A';
        } else if (average >= 75) {
            grade = 'B';
        } else if (average >= 50) {
            grade = 'C';
        }else{
            grade = 'F';
        }
        console.log(`Student: ${this.name}, Average: ${average}, Grade: ${grade}`);
    }
}
const student1 = new Student("Alice");
student1.addMarks(85, 90, 78);
student1.displayGrade();