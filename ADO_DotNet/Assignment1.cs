using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
namespace ADO_DotNet
{
    class StudentCRUD
    {
        static string connStr = "";

        public static void InsertStudent(string name, int age, string grade)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Students (Name, Age, Grade) VALUES (@Name, @Age, @Grade)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Grade", grade);
                cmd.ExecuteNonQuery();
            }
        }

        public static void GetAllStudents()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Students";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Id"]}, {reader["Name"]}, {reader["Age"]}, {reader["Grade"]}");
                }
            }
        }

        public static void UpdateStudentGrade(int id, string grade)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Students SET Grade=@Grade WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Grade", grade);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteStudent(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "DELETE FROM Students WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
    internal class Assignment1
    {
        static void Main()
        {
            StudentCRUD.InsertStudent("Alice", 20, "A");
            StudentCRUD.InsertStudent("Bob", 22, "B");

            Console.WriteLine("All Students:");
            StudentCRUD.GetAllStudents();

            StudentCRUD.UpdateStudentGrade(1, "A+");

            Console.WriteLine("After Update:");
            StudentCRUD.GetAllStudents();

            StudentCRUD.DeleteStudent(2);

            Console.WriteLine("After Delete:");
            StudentCRUD.GetAllStudents();
        }
    }


}
