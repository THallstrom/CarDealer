using CarDealer.Contexts;
using CarDealer.Menus;
using CarDealer.Repositorys;
using CarDealer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
           var service = new ServiceCollection();

            service.AddDbContext<DataContext>(options => 
            options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\EgnaProjekt\Databas\CarDealer\CarDealer\Contexts\CarDealerDb.mdf;Integrated Security=True;Connect Timeout=30"));
            service.AddScoped<MainMenu>();
            service.AddScoped<CarMenu>();
            service.AddScoped<AddCarMenu>();

            service.AddScoped<CarRepository>();
            service.AddScoped<ColorRepository>();
            service.AddScoped<FuelRepository>();
            service.AddScoped<GearBoxRepository>();
            service.AddScoped<MakerRepository>();
            service.AddScoped<YearRepository>();
            service.AddScoped<ModelRepository>();
            service.AddScoped<ConditionRepository>();

            service.AddScoped<CarService>();

            var sp = service.BuildServiceProvider();
            var mainMenu = sp.GetRequiredService<MainMenu>();
            await mainMenu.ShowMenu();
        }
    }
}
