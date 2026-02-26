class Animal {
  makeSound() {}
}

class Dog extends Animal {
  makeSound() {
    console.log("Woof Woof");
  }
}

class Cat extends Animal {
  makeSound() {
    console.log("Meow Meow");
  }
}

class Cow extends Animal {
  makeSound() {
    console.log("Moo Moo");
  }
}

let animals = [new Dog(), new Cat(), new Cow()];
animals.forEach(a => a.makeSound());