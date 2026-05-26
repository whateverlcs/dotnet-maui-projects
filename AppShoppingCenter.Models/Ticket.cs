using System;
using System.Collections.Generic;
using System.Text;

namespace AppShoppingCenter.Models;

public class Ticket
{
    public int Id { get; set; }
    public string TicketNumber { get; set; } = null!;
    public DateTimeOffset DateIn { get; set; }
    public DateTimeOffset DateOut { get; set; }
    public DateTimeOffset DateTolerance { get; set; }
    public double Price { get; set; }
}
