using Microsoft.Extensions.Primitives;

namespace CarDealer.Models;

public class CarUpdateForm
{
    public string RegNumber { get; set; } = null!;
    public string? Milage { get; set; }
    public string? Condition { get; set; }
    public bool IsSold { get; set; }
}
