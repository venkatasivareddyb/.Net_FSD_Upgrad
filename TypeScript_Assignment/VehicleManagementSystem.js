"use strict";
// Base class
class Vehicle {
    brand;
    speed;
    constructor(brand, speed) {
        this.brand = brand;
        this.speed = speed;
    }
    move() {
        console.log("Vehicle is moving");
    }
}
// Derived class Car
class Car extends Vehicle {
    fuelType;
    constructor(brand, speed, fuelType) {
        super(brand, speed);
        this.fuelType = fuelType;
    }
    // Method overriding
    move() {
        console.log(`${this.brand} Car is moving at ${this.speed} km/h using ${this.fuelType}`);
    }
}
// Derived class Bike
class Bike extends Vehicle {
    hasGear;
    constructor(brand, speed, hasGear) {
        super(brand, speed);
        this.hasGear = hasGear;
    }
    // Method overriding
    move() {
        console.log(`${this.brand} Bike is moving at ${this.speed} km/h ${this.hasGear ? "with gear" : "without gear"}`);
    }
}
const car1 = new Car("Toyota", 80, "Petrol");
const bike1 = new Bike("Yamaha", 60, true);
car1.move();
bike1.move();
