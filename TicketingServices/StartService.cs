public class StartService
{
    private TicketService _ticketService;

    public StartService(TicketService ticketService)
    {
        _ticketService = ticketService;
    }

    public void StartTicketSystem()
    {
        bool launchFlag = false;

        while (!launchFlag)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Ticket System");
            Console.WriteLine("1. Create a new ticket");
            Console.WriteLine("2. View all tickets");
            Console.WriteLine("3. Exit");
            Console.Write("Choose your destiny: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateTicket();
                    break;
                case "2":
                    ViewTickets();
                    break;
                case "3":
                    launchFlag = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    continue;
            }

            Console.WriteLine("Press any key to continue... Or press ESC to exit");

            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                launchFlag = true;
            }
        }
    }

    void CreateTicket()
    {
        Console.Clear();

        Console.Write("Please enter the ID of the ticket: ");
        int ticketId;
        while (!int.TryParse(Console.ReadLine(), out ticketId))
        {
            Console.WriteLine("Invalid input! Please enter a valid ticket Id.");
        }

        Console.Write("Please enter the summary of the ticket: ");
        string summary = Console.ReadLine();
        while (string.IsNullOrEmpty(summary))
        {
            Console.WriteLine("Invalid input! Summary cannot be empty.");
            summary = Console.ReadLine();
        }

        Console.Write("Please enter the status of the ticket: ");
        string status = Console.ReadLine();
        while (string.IsNullOrEmpty(status))
        {
            Console.WriteLine("Invalid input! Status cannot be empty");
            status = Console.ReadLine();
        }

        Console.Write("Please enter the priority of the ticket: ");
        string priority = Console.ReadLine();
        while (string.IsNullOrEmpty(priority))
        {
            Console.WriteLine("Invalid input! Priority cannot be empty.");
            priority = Console.ReadLine();
        }

        Console.Write("Please enter the submitter of the ticket: ");
        string submitter = Console.ReadLine();
        while (string.IsNullOrEmpty(submitter))
        {
            Console.WriteLine("Invalid input! Submitter cannot be empty.");
            submitter = Console.ReadLine();
        }

        Console.Write("Please enter the assigned person of the ticket: ");
        string assigned = Console.ReadLine();
        while (string.IsNullOrEmpty(assigned))
        {
            Console.WriteLine("Invalid input! Assigned person field cannot be empty.");
            assigned = Console.ReadLine();
        }

        string[] watching;
        while (true)
        {
            Console.Write("Please enter the watchers of the ticket, separated by pipe (|): ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input! Watchers field cannot be empty.");
                continue;
            }

            watching = input.Split("|");
            break;
        }

        string watchers = string.Join("|", watching);
        _ticketService.CreateTicket(ticketId, summary, status, priority, submitter, assigned, watchers);
        Console.WriteLine("Ticket created successfully!");
    }


    void ViewTickets()
    {
        var tickets = _ticketService.GetTickets();
        Console.Clear();
        Console.WriteLine("List of Tickets:\n");

        foreach (var ticket in tickets)
        {
            Console.WriteLine(ticket);
        }

        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
}