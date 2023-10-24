using System;
using System.IO;


// // Get the input from the user
// Console.WriteLine("Enter the Ticket ID:");
// int ticketId = int.Parse(Console.ReadLine());

// Console.WriteLine("Enter the Ticket Summary:");
// string summary = Console.ReadLine();

// Console.WriteLine("Enter the Ticket Status:");
// string status = Console.ReadLine();

// Console.WriteLine("Enter the Ticket Priority:");
// string priority = Console.ReadLine();

// Console.WriteLine("Enter the Ticket Submitter:");
// string submitter = Console.ReadLine();

// Console.WriteLine("Enter the Ticket Assigned:");
// string assigned = Console.ReadLine();

// Console.WriteLine("Enter the Ticket Watching (separated by '|'):");
// string watching = Console.ReadLine();

// // Create a new record in the CSV file
// string record = $"{ticketId},{summary},{status},{priority},{submitter},{assigned},\"{watching}\"";

// // Append the new record to the existing CSV file
// File.AppendAllText("Tickets.csv", Environment.NewLine + record);

// Console.WriteLine("Ticket added successfully!");
using System;

namespace TicketingSystem
{
        class Program
        {
                static void Main(string[] args)
                {


                        // Define bugTicketFileName, enhancementTicketFileName and taskTicketFileName
                        string bugTicketFileName = "BugTickets.csv";
                        string enhancementTicketFileName = "EnhancementTickets.csv";
                        string taskTicketFileName = "TaskTickets.csv";

                        var bugTicketService = new TicketService(bugTicketFileName);
                        var enhancementTicketService = new TicketService(enhancementTicketFileName);
                        var taskTicketService = new TicketService(taskTicketFileName);


                        var startService = new StartService(bugTicketService, enhancementTicketService, taskTicketService);
                        startService.StartTicketSystem();

                }
        }
}



