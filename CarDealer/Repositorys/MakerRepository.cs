using CarDealer.Contexts;
using CarDealer.Entitys;

namespace CarDealer.Repositorys;

public class MakerRepository : Repo<MakerEntity>
{
    public MakerRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
