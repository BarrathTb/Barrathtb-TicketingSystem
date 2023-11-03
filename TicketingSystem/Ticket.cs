public class Ticket
{
    private int ticketId;
    private string summary;
    private string status;
    private string priority;
    private string submitter;
    private string assigned;
    private string[] watching;

    public Ticket(int ticketId, string summary, string status, string priority, string submitter, string assigned, string[] watching)
    {
        this.ticketId = ticketId;
        this.summary = summary;
        this.status = status;
        this.priority = priority;
        this.submitter = submitter;
        this.assigned = assigned;
        this.watching = watching;
    }

    public int TicketId => ticketId;
    public string Summary => summary;
    public string Status => status;
    public string Priority => priority;
    public string Submitter => submitter;
    public string Assigned => assigned;
    public string[] Watching => watching;

    public override string ToString()
    {
        var stringWatching = string.Join("|", Watching);
        return
        "-- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --\n" +
        $"Ticket ID: {TicketId}\n" +
        $"Summary: {Summary}\n" +
        $"Status: {Status}\n" +
        $"Priority: {Priority}\n" +
        $"Submitter: {Submitter}\n" +
        $"Assigned: {Assigned}\n" +
        $"Watching: {stringWatching}\n";
    }

}