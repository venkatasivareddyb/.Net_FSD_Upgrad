using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_And_Abstract_Classes
{
    using System;

    public abstract class SalesBase
    {
        public abstract double MonthlySales(double dailySales);

        public double DailySales(double dailySales)
        {
            return dailySales;
        }
    }

    public interface ISalesYear
    {
        double AnnualSales(double monthlySales);
    }

    public class SalesSystem : SalesBase, ISalesYear
    {
        public override double MonthlySales(double dailySales)
        {
            return dailySales * 30; // Assuming 30 days
        }

        public double AnnualSales(double monthlySales)
        {
            return monthlySales * 12;
        }
    }

    class Assignment_2
    {
        static void Main()
        {
            double dailySales = 400;
            SalesSystem sales = new SalesSystem();

            Console.WriteLine("Daily Sales: Rs." + sales.DailySales(dailySales));
            double monthly = sales.MonthlySales(dailySales);
            Console.WriteLine("Monthly Sales: Rs." + monthly);
            Console.WriteLine("Annual Sales: Rs." + sales.AnnualSales(monthly));
        }
    }
}
