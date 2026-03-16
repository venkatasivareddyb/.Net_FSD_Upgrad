using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_polymorphism
{
    using System;

    public class Vehicle
    {
        public string VehicleNumber { get; set; }
        public string Brand { get; set; }
        public Vehicle(string number, string brand)
        {
            VehicleNumber = number;
            Brand = brand;
        }

        public void StartVehicle()
        {
            Console.WriteLine($"{Brand} {VehicleNumber} started.");
        }
    }

    public class Car : Vehicle
    {
        public string FuelType { get; set; }

        public Car(string number, string brand, string fuelType)
            : base(number, brand)
        {
            FuelType = fuelType;
        }

        public void ShowCarDetails()
        {
            Console.WriteLine($"Car: {Brand}, Number: {VehicleNumber}, Fuel: {FuelType}");
        }
    }

    public class Bike : Vehicle
    {
        public string BikeType { get; set; }

        public Bike(string number, string brand, string type)
            : base(number, brand)
        {
            BikeType = type;
        }

        public void ShowBikeDetails()
        {
            Console.WriteLine($"Bike: {Brand}, Number: {VehicleNumber}, Type: {BikeType}");
        }
    }

    public sealed class ElectricCar : Car
    {
        public ElectricCar(string number, string brand)
            : base(number, brand, "Electric")
        {
        }

        public void ShowElectricCarDetails()
        {
            Console.WriteLine($"Electric Car: {Brand}, Number: {VehicleNumber}, Fuel: {FuelType}");
        }
    }

    class Assignment4
    {
        static void Main()
        {
            Vehicle v1 = new Vehicle("V001", "GenericVehicle");
            v1.StartVehicle();

            Car c1 = new Car("C101", "Toyota", "Petrol");
            c1.StartVehicle();
            c1.ShowCarDetails();

            Bike b1 = new Bike("B201", "Honda", "Sports");
            b1.StartVehicle();
            b1.ShowBikeDetails();

            ElectricCar e1 = new ElectricCar("E301", "Tesla");
            e1.StartVehicle();
            e1.ShowElectricCarDetails();
        }
    }
}
