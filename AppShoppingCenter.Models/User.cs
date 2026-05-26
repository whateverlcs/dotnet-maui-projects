using System;
using System.Collections.Generic;
using System.Text;

namespace AppShoppingCenter.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? AccessCode { get; set; }
    public DateTimeOffset? AccessCodeValid { get; set; }
}
