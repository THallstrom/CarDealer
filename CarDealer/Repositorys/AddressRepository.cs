using CarDealer.Contexts;
using CarDealer.Entitys;

namespace CarDealer.Repositorys
{
    public class AddressRepository : Repo<AddressEntity>
    {
        public AddressRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
