using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace CarDealer.Models
{
    public class CarRegistrationForm
    {
        public string Maker { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string RegNumber { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Fuel { get; set; } = null!;
        public string Gearbox { get; set; } = null!;
        public string ModelYear { get; set; } = null!;
        public bool IsSold { get; set; } = false;
        public string Milage { get; set; } = null!;
        public string Condition { get; set; } = null!;
    }
}
