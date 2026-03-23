namespace C__File_Handling
{
    class Assignment1
    {
        static string filePath = "employee_log.txt";

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1. Add Login Entry");
                Console.WriteLine("2. Update Logout Time");
                Console.WriteLine("3. View All Logs");
                Console.WriteLine("4. Exit");
                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());

                try
                {
                    if (choice == 1) AddLogin();
                    else if (choice == 2) UpdateLogout();
                    else if (choice == 3) ViewLogs();
                    else break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        static void AddLogin()
        {
            Console.Write("Employee Id: ");
            string id = Console.ReadLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            string loginTime = DateTime.Now.ToString();

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{id}|{name}|{loginTime}|");
            }
            Console.WriteLine("Login recorded.");
        }

        static void UpdateLogout()
        {
            Console.Write("Employee Id: ");
            string id = Console.ReadLine();
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split('|');
                if (parts[0] == id && parts.Length == 4 && string.IsNullOrEmpty(parts[3]))
                {
                    parts[3] = DateTime.Now.ToString();
                    lines[i] = string.Join("|", parts);
                    break;
                }
            }
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Logout updated.");
        }

        static void ViewLogs()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
}

