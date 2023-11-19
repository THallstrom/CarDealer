using Microsoft.Identity.Client;

namespace CarDealer.Entitys
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;
        public int CarId { get; set; }
        public CarEntity Car { get; set; } = null!;
    }
}
