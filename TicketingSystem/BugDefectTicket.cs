public class BugDefectTicket : Ticket
{
    public string Severity { get; set; }

    public BugDefectTicket(int ticketId, string summary, string status, string priority, string submitter, string assigned, string[] watching, string severity)
        : base(ticketId, summary, status, priority, submitter, assigned, watching)
    {
        Severity = severity;
    }
}
