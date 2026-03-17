using System;

using System;

namespace Exception_Handling
{
    public class TicketBookingException : Exception
    {
        public TicketBookingException(string message) : base(message) { }
    }

    public class MovieTheater
    {
        private int availableTickets = 15;

        public void BookTickets(int requestedTickets)
        {
            if (requestedTickets > availableTickets)
            {
                throw new TicketBookingException("Not enough tickets available!");
            }
            else
            {
                availableTickets -= requestedTickets;
                Console.WriteLine($"Successfully booked {requestedTickets} tickets. Remaining: {availableTickets}");
            }
        }
    }

    class TheaterProgram
    {
        static void Main()
        {
            MovieTheater theater = new MovieTheater();

            Console.WriteLine("Do you want to book tickets? (yes/no)");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "yes")
            {
                Console.WriteLine("Enter number of tickets to book:");
                int tickets = Convert.ToInt32(Console.ReadLine());

                try
                {
                    theater.BookTickets(tickets);
                }
                catch (TicketBookingException ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Thank you! Visit again.");
            }
        }
    }
}
