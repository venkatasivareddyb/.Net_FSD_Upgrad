using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_polymorphism
{
    using System;

    class Furniture
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string FurnitureType { get; set; }
        public int Qty { get; set; }
        public double TotalAmt { get; set; }
        public string PaymentMode { get; set; }

        public virtual void GetData()
        {
            Console.Write("Enter Order Id: ");
            OrderId = int.Parse(Console.ReadLine());

            OrderDate = DateTime.Now;

            Console.Write("Enter Furniture Type (Chair/Cot): ");
            FurnitureType = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            Qty = int.Parse(Console.ReadLine());

            Console.Write("Enter Payment Mode (Credit/Debit): ");
            PaymentMode = Console.ReadLine();
        }

        public virtual void ShowData()
        {
            Console.WriteLine("\n--- Furniture Order Details ---");
            Console.WriteLine($"OrderId: {OrderId}");
            Console.WriteLine($"OrderDate: {OrderDate}");
            Console.WriteLine($"FurnitureType: {FurnitureType}");
            Console.WriteLine($"Quantity: {Qty}");
            Console.WriteLine($"PaymentMode: {PaymentMode}");
            Console.WriteLine($"Total Amount: {TotalAmt}");
        }
    }

    class Chair : Furniture
    {
        public string ChairType { get; set; }
        public string Purpose { get; set; }
        public string MaterialDetail { get; set; }
        public double Rate { get; set; }

        public override void GetData()
        {
            base.GetData();

            Console.Write("Enter Chair Type (Wood/Steel/Plastic): ");
            ChairType = Console.ReadLine();

            Console.Write("Enter Purpose (Home/Office): ");
            Purpose = Console.ReadLine();

            Console.Write("Enter Material Detail (Teak/Rose/Gray/Green/Plastic Color): ");
            MaterialDetail = Console.ReadLine();

            Console.Write("Enter Rate: ");
            Rate = double.Parse(Console.ReadLine());

            TotalAmt = Rate * Qty;
        }

        public override void ShowData()
        {
            base.ShowData();
            Console.WriteLine($"ChairType: {ChairType}");
            Console.WriteLine($"Purpose: {Purpose}");
            Console.WriteLine($"MaterialDetail: {MaterialDetail}");
            Console.WriteLine($"Rate: {Rate}");
        }
    }

    class Cot : Furniture
    {
        public string CotType { get; set; }
        public string MaterialDetail { get; set; }
        public string Capacity { get; set; }
        public double Rate { get; set; }

        public override void GetData()
        {
            base.GetData();

            Console.Write("Enter Cot Type (Wood/Steel): ");
            CotType = Console.ReadLine();

            Console.Write("Enter Material Detail (Teak/Rose/Gray/Green): ");
            MaterialDetail = Console.ReadLine();

            Console.Write("Enter Capacity (Single/Double): ");
            Capacity = Console.ReadLine();

            Console.Write("Enter Rate: ");
            Rate = double.Parse(Console.ReadLine());

            TotalAmt = Rate * Qty;
        }

        public override void ShowData()
        {
            base.ShowData();
            Console.WriteLine($"CotType: {CotType}");
            Console.WriteLine($"MaterialDetail: {MaterialDetail}");
            Console.WriteLine($"Capacity: {Capacity}");
            Console.WriteLine($"Rate: {Rate}");
        }
    }

    class Assignment6
    {
        static void Main()
        {
            Console.Write("Enter Furniture Type (Chair/Cot): ");
            string type = Console.ReadLine();

            Furniture furniture;

            if (type.Equals("Chair", StringComparison.OrdinalIgnoreCase))
            {
                furniture = new Chair();
            }
            else if (type.Equals("Cot", StringComparison.OrdinalIgnoreCase))
            {
                furniture = new Cot();
            }
            else
            {
                Console.WriteLine("Invalid Furniture Type!");
                return;
            }

            furniture.GetData();
            furniture.ShowData();
        }
    }
}
