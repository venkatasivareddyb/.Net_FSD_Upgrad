class Shapes {
    area(length: number, breadth: number): number; // Rectangle
    area(base: number, height: number, isTriangle: boolean): number; // Triangle
    area(radius: number): number; // Circle
    area(side: number, isSquare: boolean): number; // Square

    area(...args: any[]): number {
        if (args.length === 2 && typeof args[0] === "number" && typeof args[1] === "number") {
            return args[0] * args[1]; // Rectangle
        } else if (args.length === 3 && args[2] === true) {
            return 0.5 * args[0] * args[1]; // Triangle
        } else if (args.length === 1) {
            return Math.PI * args[0] * args[0]; // Circle
        } else if (args.length === 2 && args[1] === true) {
            return args[0] * args[0]; // Square
        }
        return 0;
    }
}


const shape = new Shapes();
console.log("Rectangle Area: " + shape.area(10, 20));
console.log("Triangle Area: " + shape.area(10, 15, true));
console.log("Circle Area: " + shape.area(7));
console.log("Square Area: " + shape.area(5, true));
