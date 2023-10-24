using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class TicketService
{
    private List<Ticket> _tickets;
    private string _ticketFile;

    public TicketService(string ticketFile)
    {

        _ticketFile = ticketFile;
        _tickets = ReadTicketFile();
    }

    private List<Ticket> ReadTicketFile()
    {
        var tickets = new List<Ticket>();

        if (File.Exists(_ticketFile))
        {
            var lines = File.ReadAllLines(_ticketFile);
            foreach (var line in lines.Skip(1)) // Skip the header row
            {
                var fields = line.Split(',');

                int id = int.Parse(fields[0]);
                string summary = fields[1];
                string status = fields[2];
                string priority = fields[3];
                string submitter = fields[4];
                string assigned = fields[5];
                string[] watching = fields[6].Split('|');

                if (fields.Length == 8)
                {
                    // Bug/Defect ticket
                    string severity = fields[7];
                    var ticket = new BugDefectTicket(id, summary, status, priority, submitter, assigned, watching, severity);
                    tickets.Add(ticket);
                }
                else if (fields.Length == 11)
                {
                    // Enhancement ticket
                    string software = fields[7];
                    double cost = double.Parse(fields[8]);
                    string reason = fields[9];
                    int estimate = int.Parse(fields[10]);
                    var ticket = new EnhancementTicket(id, summary, status, priority, submitter, assigned, watching, software, cost, reason, estimate);
                    tickets.Add(ticket);
                }
                else if (fields.Length == 9)
                {
                    // Task ticket
                    string projectName = fields[7];
                    DateTime dueDate = DateTime.Parse(fields[8]);
                    var ticket = new TaskTicket(id, summary, status, priority, submitter, assigned, watching, projectName, dueDate);
                    tickets.Add(ticket);
                }
            }
        }
        else
        {
            Console.WriteLine("Could not find the ticket file: " + _ticketFile);
        }

        return tickets;
    }

    public void AddTicket(Ticket ticket)
    {
        _tickets.Add(ticket);
    }
    public IEnumerable<Ticket> GetTicketsByType(TicketType type)
    {
        switch (type)
        {
            case TicketType.BugDefectTicket:
                return _tickets.OfType<BugDefectTicket>();
            case TicketType.EnhancementTicket:
                return _tickets.OfType<EnhancementTicket>();
            case TicketType.TaskTicket:
                return _tickets.OfType<TaskTicket>();
            default:
                throw new ArgumentException("Invalid ticket type");
        }
    }

    public void WriteTicketsToFileByType()
    {
        foreach (var ticket in _tickets)
        {
            var newLine = ticket.ToString();
            var header = GetTicketHeader(ticket);

            if (ticket is BugDefectTicket)
            {
                if (!File.Exists("BugTickets.csv"))
                    File.WriteAllText("BugTickets.csv", header + Environment.NewLine);
                File.AppendAllText("BugTickets.csv", newLine + Environment.NewLine);
            }
            else if (ticket is EnhancementTicket)
            {
                if (!File.Exists("EnhancementTickets.csv"))
                    File.WriteAllText("EnhancementTickets.csv", header + Environment.NewLine);
                File.AppendAllText("EnhancementTickets.csv", newLine + Environment.NewLine);
            }
            else if (ticket is TaskTicket)
            {
                if (!File.Exists("TaskTickets.csv"))
                    File.WriteAllText("TaskTickets.csv", header + Environment.NewLine);
                File.AppendAllText("TaskTickets.csv", newLine + Environment.NewLine);
            }
        }
    }





    public void CreateBugDefectTicket(int id, string summary, string status, string priority, string submitter, string assigned, string[] watching, string severity)
    {
        var ticket = new BugDefectTicket(id, summary, status, priority, submitter, assigned, watching, severity);
        _tickets.Add(ticket);
    }

    public void CreateEnhancementTicket(int id, string summary, string status, string priority, string submitter, string assigned, string[] watching, string software, double cost, string reason, int estimate)
    {
        var ticket = new EnhancementTicket(id, summary, status, priority, submitter, assigned, watching, software, cost, reason, estimate);
        _tickets.Add(ticket);
    }

    public void CreateTaskTicket(int id, string summary, string status, string priority, string submitter, string assigned, string[] watching, string projectName, DateTime dueDate)
    {
        var ticket = new TaskTicket(id, summary, status, priority, submitter, assigned, watching, projectName, dueDate);
        _tickets.Add(ticket);
    }

    public List<Ticket> GetTickets()
    {
        return _tickets;
    }

    private string GetTicketHeader(Ticket ticket)
    {
        if (_tickets.Count > 0)
        {
            // Determine the ticket type based on the first ticket in the list
            var firstTicket = _tickets[0];
            if (firstTicket is BugDefectTicket)
            {
                return "Id,Summary,Status,Priority,Submitter,Assigned,Watching,Severity";
            }
            else if (firstTicket is EnhancementTicket)
            {
                return "Id,Summary,Status,Priority,Submitter,Assigned,Watching,Software,Cost,Reason,Estimate";
            }
            else if (firstTicket is TaskTicket)
            {
                return "Id,Summary,Status,Priority,Submitter,Assigned,Watching,ProjectName,DueDate";
            }
        }

        // Default to the original format if no tickets are available
        return "Id,Summary,Status,Priority,Submitter,Assigned,Watching";
    }
}
