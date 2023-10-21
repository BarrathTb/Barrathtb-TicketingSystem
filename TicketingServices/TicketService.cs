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

                var id = int.Parse(fields[0]);
                var summary = fields[1];
                var status = fields[2];
                var priority = fields[3];
                var submitter = fields[4];
                var assigned = fields[5];
                var watching = fields[6].Split('|');

                var ticket = new Ticket(id, summary, status, priority, submitter, assigned, watching);
                tickets.Add(ticket);
            }
        }
        else
        {
            Console.WriteLine("Could not find ticket file: " + _ticketFile);
        }

        return tickets;
    }

    public void AddTicket(Ticket ticket)
    {
        _tickets.Add(ticket);
    }

    public void WriteTicketsToFile()
    {
        var ticketLines = new List<string> { "Id,Summary,Status,Priority,Submitter,Assigned,Watching" }; // Header
        ticketLines.AddRange(_tickets.Select(t => t.ToString()));
        File.WriteAllLines(_ticketFile, ticketLines);
    }

    public void CreateTicket(int id, string summary, string status, string priority, string submitter, string assigned, string watching)
    {
        string[] watchers = watching.Split('|');
        var ticket = new Ticket(id, summary, status, priority, submitter, assigned, watchers);
        _tickets.Add(ticket);
    }

    public List<Ticket> GetTickets()
    {
        return _tickets;
    }
}
