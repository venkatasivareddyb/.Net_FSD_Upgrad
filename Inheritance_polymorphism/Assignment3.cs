using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_polymorphism
{
    class Order
    {
        public int OrderId { get; set; }
        public double OrderAmount { get; set; }

        public Order(int id, double amount)
        {
            OrderId = id;
            OrderAmount = amount;
        }

        public virtual double CalculateShippingCost()
        {
            return 50; // default
        }
    }

    class StandardOrder : Order
    {
        public StandardOrder(int id, double amount) : base(id, amount) { }
        public override double CalculateShippingCost() => 50;
    }

    class ExpressOrder : Order
    {
        public ExpressOrder(int id, double amount) : base(id, amount) { }
        public override double CalculateShippingCost() => 100;
    }

    class InternationalOrder : Order
    {
        public InternationalOrder(int id, double amount) : base(id, amount) { }
        public override double CalculateShippingCost() => 500;
    }

    class Assignment3
    {
        static void Main()
        {
            var orders = new List<Order>
        {
            new StandardOrder(1, 1000),
            new ExpressOrder(2, 2000),
            new InternationalOrder(3, 5000)
        };

            foreach (var order in orders)
            {
                Console.WriteLine($"Order {order.OrderId} Shipping: {order.CalculateShippingCost()}");
            }
        }
    }
}
