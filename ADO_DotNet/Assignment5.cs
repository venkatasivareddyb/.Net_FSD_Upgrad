using Microsoft.Data.SqlClient;
using System;

namespace ADO_DotNet
{
    class Library
    {
        static string connStr = "";

        public static void AddBook(string title, string author, decimal price)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Books (Title, Author, Price) VALUES (@Title, @Author, @Price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Author", author);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.ExecuteNonQuery();
            }
        }

        public static void ViewBooks()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Books";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    Console.WriteLine($"{reader["BookId"]}, {reader["Title"]}, {reader["Author"]}, {reader["Price"]}");
            }
        }

        public static void UpdateBook(int id, string title, string author, decimal price)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Books SET Title=@Title, Author=@Author, Price=@Price WHERE BookId=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Author", author);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteBook(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "DELETE FROM Books WHERE BookId=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void SearchBook(string name)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Books WHERE Title LIKE @Name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", "%" + name + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    Console.WriteLine($"{reader["BookId"]}, {reader["Title"]}, {reader["Author"]}, {reader["Price"]}");
            }
        }
    }
    internal class Assignment5
    {
        static void Main()
        {
            Library.AddBook("C# Basics", "Author A", 299);
            Library.AddBook("SQL Guide", "Author B", 399);

            Console.WriteLine("All Books:");
            Library.ViewBooks();

            Library.UpdateBook(1, "C# Basics Updated", "Author A", 349);

            Console.WriteLine("After Update:");
            Library.ViewBooks();

            Console.WriteLine("Search Results for 'SQL':");
            Library.SearchBook("SQL");

            Library.DeleteBook(2);

            Console.WriteLine("After Delete:");
            Library.ViewBooks();
        }


    }
}
