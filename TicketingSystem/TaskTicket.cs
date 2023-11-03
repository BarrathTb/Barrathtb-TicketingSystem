public class TaskTicket : Ticket
{
    public string ProjectName { get; set; }
    public DateTime DueDate { get; set; }

    public TaskTicket(int ticketId, string summary, string status, string priority, string submitter, string assigned, string[] watching, string projectName, DateTime dueDate)
        : base(ticketId, summary, status, priority, submitter, assigned, watching)
    {
        ProjectName = projectName;
        DueDate = dueDate;
    }

    public override string ToString()
    {
        var baseString = base.ToString(); // Calls the base (Ticket) ToString method
        return
        $"{baseString}" +
        $"Project Name: {ProjectName}\n" +
        $"Due Date: {DueDate}\n" +
        "-- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --\n";
    }
}
