using System;
using System.Collections.Generic;
using System.Text;
public class TicketGenerator
{
    public string GenerateTicketList(List<Ticket> ticketList)
    {
        var ticketLineItem = new StringBuilder();

        foreach (var ticket in ticketList)
        {
            if (ticket is BugDefectTicket bugDefect)
            {
                // Generate lines for BugDefectTicket
                ticketLineItem.Append($"{bugDefect.TicketId},{bugDefect.Summary},{bugDefect.Status},{bugDefect.Priority},{bugDefect.Submitter},{bugDefect.Assigned},{string.Join("|", bugDefect.Watching)},{bugDefect.Severity}");
            }
            else if (ticket is EnhancementTicket enhancement)
            {
                // Generate lines for EnhancementTicket
                ticketLineItem.Append($"{enhancement.TicketId},{enhancement.Summary},{enhancement.Status},{enhancement.Priority},{enhancement.Submitter},{enhancement.Assigned},{string.Join("|", enhancement.Watching)},{enhancement.Software},{enhancement.Cost},{enhancement.Reason},{enhancement.Estimate}");
            }
            else if (ticket is TaskTicket task)
            {
                // Generate lines for TaskTicket
                ticketLineItem.Append($"{task.TicketId},{task.Summary},{task.Status},{task.Priority},{task.Submitter},{task.Assigned},{string.Join("|", task.Watching)},{task.ProjectName},{task.DueDate}");
            }

            ticketLineItem.Append("\n");
        }

        return ticketLineItem.ToString();
    }
}

