using CarDealer.Contexts;
using CarDealer.Entitys;

namespace CarDealer.Repositorys
{
    public class ColorRepository : Repo<ColorEntity>
    {
        public ColorRepository(DataContext dataContext) : base(dataContext)
        {
        }

        
    }
}
