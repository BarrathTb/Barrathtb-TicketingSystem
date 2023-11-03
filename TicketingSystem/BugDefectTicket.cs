public class BugDefectTicket : Ticket
{
    public string Severity { get; set; }

    // Added constructor
    public BugDefectTicket(int ticketId, string summary, string status, string priority, string submitter, string assigned, string[] watching, string severity) :
        base(ticketId, summary, status, priority, submitter, assigned, watching)
    {
        Severity = severity;
    }

    public override string ToString()
    {
        var baseString = base.ToString(); // Calls the base (Ticket) ToString method
        return
        $"{baseString}\nSeverity: {Severity}\n" +
        "-- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --\n";
    }
}

