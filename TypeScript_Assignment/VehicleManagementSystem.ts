// Base class
class Vehicle {
    brand: string;
    speed: number;

    constructor(brand: string, speed: number) {
        this.brand = brand;
        this.speed = speed;
    }

    move(): void {
        console.log("Vehicle is moving");
    }
}

// Derived class Car
class Car extends Vehicle {
    fuelType: string;

    constructor(brand: string, speed: number, fuelType: string) {
        super(brand, speed);
        this.fuelType = fuelType;
    }

    // Method overriding
    move(): void {
        console.log(`${this.brand} Car is moving at ${this.speed} km/h using ${this.fuelType}`);
    }
}

// Derived class Bike
class Bike extends Vehicle {
    hasGear: boolean;

    constructor(brand: string, speed: number, hasGear: boolean) {
        super(brand, speed);
        this.hasGear = hasGear;
    }

    // Method overriding
    move(): void {
        console.log(`${this.brand} Bike is moving at ${this.speed} km/h ${this.hasGear ? "with gear" : "without gear"}`);
    }
}
const car1 = new Car("Toyota", 80, "Petrol");
const bike1 = new Bike("Yamaha", 60, true);

car1.move();
bike1.move();
