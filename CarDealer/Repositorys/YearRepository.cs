using CarDealer.Contexts;
using CarDealer.Entitys;

namespace CarDealer.Repositorys;

public class YearRepository : Repo<YearEntity>
{
    public YearRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
