using CarDealer.Contexts;
using CarDealer.Entitys;

namespace CarDealer.Repositorys;

public class FuelRepository : Repo<FuelEntity>
{
    public FuelRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
