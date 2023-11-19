using CarDealer.Contexts;
using CarDealer.Entitys;

namespace CarDealer.Repositorys;

public class ConditionRepository : Repo<ConditionEntity>
{
    public ConditionRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
