using System;
using System.Collections.Generic;
using System.Text;
using AppShoppingCenter.Models.Enums;

namespace AppShoppingCenter.Models;

public class Establishment
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Localization { get; set; } = null!;
    public string? Phone { get; set; }
    public EstablishmentType Type { get; set; }
    public string Cover { get; set; } = null!;
    public string Logo { get; set; } = null!;
}
