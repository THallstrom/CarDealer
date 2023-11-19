using CarDealer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        // Entity
        public DbSet<CarEntity> Car { get; set; }
        public DbSet<ColorEntity> Color { get; set; }
        public DbSet<FuelEntity> Fuel { get; set; }
        public DbSet<GearBoxEntity> GearBox { get; set; }
        public DbSet<MakerEntity> Maker { get; set; }
        public DbSet<YearEntity> Year { get; set; }
        public DbSet<ModelEntity> CarModel {  get; set; }
        public DbSet<ConditionEntity> Condition { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
    }
}
