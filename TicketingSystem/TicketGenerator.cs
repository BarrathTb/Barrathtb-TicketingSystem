public class TicketGenerator
{
    public string ticketHeader = "TicketId: | Summary: | Status: | Priority: | Submitter: | Assigned: | Watching: ";
    public string TicketHeader => ticketHeader;

    public string GenerateTicketList(List<Ticket> ticketList)
    {
        var ticketLineItem = "";

        foreach (var ticket in ticketList)
        {
            ticketLineItem += $"{ticket.TicketId} | {ticket.Summary} | {ticket.Status} | {ticket.Priority} | {ticket.Submitter} | {ticket.Assigned} | ";

            foreach (var watcher in ticket.Watching)
            {
                ticketLineItem += $"{watcher} | ";
            }
            ticketLineItem = $"{ticketLineItem[..^1]}\n";
        }
        return ticketLineItem;
    }

    public List<Ticket> GenerateTicket(List<string> ticketLines)
    {
        var ticketList = new List<Ticket>();
        var ticketArray = ticketLines.ToArray();

        foreach (var ticketLine in ticketArray)
        {
            if (ticketArray.Length >= 1)
            {
                var ticketParts = ticketLine.Split(',');
                var newTicket = new Ticket(Convert.ToInt16(ticketParts[0]), ticketParts[1], ticketParts[2], ticketParts[3], ticketParts[4], ticketParts[5], ticketParts[6].Split("|"));

                ticketList.Add(newTicket);
            }

        }
        return ticketList;
    }
}