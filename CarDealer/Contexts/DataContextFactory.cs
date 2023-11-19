using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarDealer.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\EgnaProjekt\Databas\CarDealer\CarDealer\Contexts\CarDealerDb.mdf;Integrated Security=True;Connect Timeout=30");

        return new DataContext(optionBuilder.Options);
    }
}
