public class EnhancementTicket : Ticket
{
    public string Software { get; set; }
    public double Cost { get; set; }
    public string Reason { get; set; }
    public int Estimate { get; set; }

    public EnhancementTicket(int ticketId, string summary, string status, string priority, string submitter, string assigned, string[] watching, string software, double cost, string reason, int estimate)
        : base(ticketId, summary, status, priority, submitter, assigned, watching)
    {
        Software = software;
        Cost = cost;
        Reason = reason;
        Estimate = estimate;
    }

    public override string ToString()
    {
        var baseString = base.ToString(); // Calls the base (Ticket) ToString method
        return
        $"{baseString}\nSoftware: {Software}\nCost: {Cost}\nReason: {Reason}\nEstimate: {Estimate}\n" +
        "-- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --\n";
    }
}
