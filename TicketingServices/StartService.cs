public class StartService
{
    private TicketService _enhancementTicketService;
    private TicketService _bugTicketService;
    private TicketService _taskTicketService;

    public StartService()
    {
    }

    public StartService(TicketService bugTicketService, TicketService enhancementTicketService, TicketService taskTicketService)
    {
        _bugTicketService = bugTicketService;
        _enhancementTicketService = enhancementTicketService;
        _taskTicketService = taskTicketService;
    }

    public void StartTicketSystem()
    {
        bool launchFlag = false;

        while (!launchFlag)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Ticket System");
            Console.WriteLine("1. Create a new Bug/Defect ticket");
            Console.WriteLine("2. Create a new Enhancement ticket");
            Console.WriteLine("3. Create a new Task ticket");
            Console.WriteLine("4. View all tickets");
            Console.WriteLine("5. Exit");
            Console.Write("Choose your destiny: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateBugDefectTicket();
                    break;
                case "2":
                    CreateEnhancementTicket();
                    break;
                case "3":
                    CreateTaskTicket();
                    break;
                case "4":
                    ViewTickets();
                    break;
                case "5":
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

    void CreateBugDefectTicket()
    {
        Console.Clear();

        // Prompt and collect information for Bug/Defect ticket
        Console.Write("Please enter the ID of the Bug/Defect ticket: ");
        int ticketId;
        while (!int.TryParse(Console.ReadLine(), out ticketId))
        {
            Console.WriteLine("Invalid input! Please enter a valid ticket Id.");
        }

        // Collect additional fields specific to Bug/Defect tickets
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

        Console.Write("Please enter the watchers of the ticket, separated by pipe (|): ");
        string input = Console.ReadLine();
        string[] watching;
        while (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Invalid input! Watchers field cannot be empty.");
            input = Console.ReadLine();
        }

        watching = input.Split("|");
        string watchers = string.Join("|", watching);
        Console.Write("Please enter the severity of the Bug/Defect: ");
        string severity = Console.ReadLine();
        while (string.IsNullOrEmpty(severity))
        {
            Console.WriteLine("Invalid input! Severity cannot be empty.");
            severity = Console.ReadLine();
        }

        // Create the Bug/Defect ticket
        BugDefectTicket ticket = new BugDefectTicket(ticketId, summary, status, priority, submitter, assigned, watching, severity);

        // Add the ticket to the service
        _bugTicketService.AddTicket(ticket);

        _bugTicketService.WriteTicketsToFileByType();
        Console.WriteLine("Bug/Defect ticket created successfully!");
    }

    void CreateEnhancementTicket()
    {
        Console.Clear();

        // Prompt and collect information for Enhancement ticket
        Console.Write("Please enter the ID of the Enhancement ticket: ");
        int ticketId;
        while (!int.TryParse(Console.ReadLine(), out ticketId))
        {
            Console.WriteLine("Invalid input! Please enter a valid ticket Id.");
        }

        Console.Write("Please enter the summary of the Enhancement ticket: ");
        string summary = Console.ReadLine();
        while (string.IsNullOrEmpty(summary))
        {
            Console.WriteLine("Invalid input! Summary cannot be empty.");
            summary = Console.ReadLine();
        }

        Console.Write("Please enter the status of the Enhancement ticket: ");
        string status = Console.ReadLine();
        while (string.IsNullOrEmpty(status))
        {
            Console.WriteLine("Invalid input! Status cannot be empty.");
            status = Console.ReadLine();
        }

        Console.Write("Please enter the priority of the Enhancement ticket: ");
        string priority = Console.ReadLine();

        while (string.IsNullOrEmpty(priority))
        {
            Console.WriteLine("Invalid input! Priority cannot be empty.");
            priority = Console.ReadLine();
        }

        Console.Write("Please enter the submitter of the Enhancement ticket: ");
        string submitter = Console.ReadLine();
        while (string.IsNullOrEmpty(submitter))
        {
            Console.WriteLine("Invalid input! Submitter cannot be empty.");
            submitter = Console.ReadLine();
        }

        Console.Write("Please enter the assigned person of the Enhancement ticket: ");
        string assigned = Console.ReadLine();
        while (string.IsNullOrEmpty(assigned))
        {
            Console.WriteLine("Invalid input! Assigned person field cannot be empty.");
            assigned = Console.ReadLine();
        }

        Console.Write("Please enter the watchers of the Enhancement ticket, separated by pipe (|): ");
        string input = Console.ReadLine();
        string[] watching;
        while (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Invalid input! Watchers field cannot be empty.");
            input = Console.ReadLine();
        }

        watching = input.Split("|");
        string watchers = string.Join("|", watching);

        Console.Write("Please enter the software for the Enhancement ticket: ");
        string software = Console.ReadLine();
        while (string.IsNullOrEmpty(software))
        {
            Console.WriteLine("Invalid input! Software field cannot be empty.");
            software = Console.ReadLine();
        }

        Console.Write("Please enter the cost for the Enhancement ticket: ");
        double cost;
        while (!double.TryParse(Console.ReadLine(), out cost))
        {
            Console.WriteLine("Invalid input! Cost should be a valid number.");
        }

        Console.Write("Please enter the reason for the Enhancement ticket: ");
        string reason = Console.ReadLine();
        while (string.IsNullOrEmpty(reason))
        {
            Console.WriteLine("Invalid input! Reason field cannot be empty.");
            reason = Console.ReadLine();
        }

        Console.Write("Please enter the estimate (in hours) for the Enhancement ticket: ");
        int estimate;
        while (!int.TryParse(Console.ReadLine(), out estimate))
        {
            Console.WriteLine("Invalid input! Estimate should be a valid number.");
        }

        // Create the Enhancement ticket
        EnhancementTicket ticket = new EnhancementTicket(ticketId, summary, status, priority, submitter, assigned, watching, software, cost, reason, estimate);

        // Add the ticket to the service
        _enhancementTicketService.AddTicket(ticket);

        _enhancementTicketService.WriteTicketsToFileByType();
        Console.WriteLine("Enhancement ticket created successfully!");
    }

    void CreateTaskTicket()
    {
        Console.Clear();

        // Prompt and collect information for Task ticket
        Console.Write("Please enter the ID of the Task ticket: ");
        int ticketId;
        while (!int.TryParse(Console.ReadLine(), out ticketId))
        {
            Console.WriteLine("Invalid input! Please enter a valid ticket Id.");
        }

        Console.Write("Please enter the summary of the Task ticket: ");
        string summary = Console.ReadLine();
        while (string.IsNullOrEmpty(summary))
        {
            Console.WriteLine("Invalid input! Summary cannot be empty.");
            summary = Console.ReadLine();
        }

        Console.Write("Please enter the status of the Task ticket: ");
        string status = Console.ReadLine();
        while (string.IsNullOrEmpty(status))
        {
            Console.WriteLine("Invalid input! Status cannot be empty.");
            status = Console.ReadLine();
        }

        Console.Write("Please enter the priority of the Task ticket: ");
        string priority = Console.ReadLine();
        while (string.IsNullOrEmpty(priority))
        {
            Console.WriteLine("Invalid input! Priority cannot be empty.");
            priority = Console.ReadLine();
        }

        Console.Write("Please enter the submitter of the Task ticket: ");
        string submitter = Console.ReadLine();
        while (string.IsNullOrEmpty(submitter))
        {
            Console.WriteLine("Invalid input! Submitter cannot be empty.");
            submitter = Console.ReadLine();
        }

        Console.Write("Please enter the assigned person of the Task ticket: ");
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

        Console.Write("Please enter the project name of the Task ticket: ");
        string projectName = Console.ReadLine();
        while (string.IsNullOrEmpty(projectName))
        {
            Console.WriteLine("Invalid input! Project name cannot be empty.");
            projectName = Console.ReadLine();
        }

        Console.Write("Please enter the due date of the Task ticket (yyyy-MM-dd): ");
        DateTime dueDate;
        while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
        {
            Console.WriteLine("Invalid input! Please enter a valid due date in the format yyyy-MM-dd.");
        }

        // Create the Task ticket
        TaskTicket ticket = new TaskTicket(ticketId, summary, status, priority, submitter, assigned, watching, projectName, dueDate);

        // Add the ticket to the service
        _taskTicketService.AddTicket(ticket);

        _taskTicketService.WriteTicketsToFileByType();
        Console.WriteLine("Task ticket created successfully!");
    }


    void ViewTickets()
    {
        Console.Clear();
        Console.WriteLine("Please choose the type of tickets to view:");
        Console.WriteLine("1. Bug/Defect Tickets");
        Console.WriteLine("2. Enhancement Tickets");
        Console.WriteLine("3. Task Tickets");
        Console.Write("Enter your choice: ");

        var ticketType = Console.ReadLine();

        IEnumerable<Ticket> tickets;

        switch (ticketType)
        {
            case "1":
                tickets = _bugTicketService.GetTicketsByType(TicketType.BugDefectTicket);
                break;
            case "2":
                tickets = _enhancementTicketService.GetTicketsByType(TicketType.EnhancementTicket);
                break;
            case "3":
                tickets = _taskTicketService.GetTicketsByType(TicketType.TaskTicket);
                break;
            default:
                Console.WriteLine("Invalid choice!");
                return;
        }


        if (tickets.Any())
        {
            foreach (var ticket in tickets)
            {
                Console.WriteLine(ticket);
            }
        }
        else
        {
            Console.WriteLine("No tickets of given type found.");
        }

        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
    }
}