using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;
namespace ADO_DotNet
{
    class ProductInventory
    {
        static string connStr = "Data Source=.;Initial Catalog=ShopDB;Integrated Security=True";

        public static void ManageProducts()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Products");

                DataTable table = ds.Tables["Products"];
                foreach (DataRow row in table.Rows)
                    Console.WriteLine($"{row["ProductId"]}, {row["ProductName"]}, {row["Price"]}, {row["Stock"]}");

                DataRow newRow = table.NewRow();
                newRow["ProductName"] = "Keyboard";
                newRow["Price"] = 1200;
                newRow["Stock"] = 10;
                table.Rows.Add(newRow);

                table.Rows[0]["Price"] = 999;

                table.Rows[1].Delete();

                adapter.Update(ds, "Products");
            }
        }
    }
    internal class Assignment3
    {
        static void Main()
            {
                ProductInventory.ManageProducts();
            }
    }
}
