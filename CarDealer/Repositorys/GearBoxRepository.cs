using CarDealer.Contexts;
using CarDealer.Entitys;

namespace CarDealer.Repositorys;

public class GearBoxRepository : Repo<GearBoxEntity>
{
    public GearBoxRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
