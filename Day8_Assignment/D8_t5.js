class Employee {
  constructor(name, salary) {
    this.name = name;
    this.salary = salary;
  }

  getDetails() {
    console.log(`Name: ${this.name}, Salary: ${this.salary}`);
  }
}

class Manager extends Employee {
  constructor(name, salary, bonus) {
    super(name, salary);
    this.bonus = bonus;
  }

  getTotalSalary() {
    super.getDetails();
    console.log(`Total Salary (with bonus): ${this.salary + this.bonus}`);
  }
}

class Director extends Manager {
  constructor(name, salary, bonus, stockOptions) {
    super(name, salary, bonus);
    this.stockOptions = stockOptions;
  }

  getFullCompensation() {
    super.getTotalSalary();
    console.log(`Full Compensation (including stock options): ${this.salary + this.bonus + this.stockOptions}`);
  }
}

const director = new Director("Alice", 50000, 10000, 20000);
director.getFullCompensation();