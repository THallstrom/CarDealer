using CarDealer.Contexts;
using CarDealer.Entitys;

namespace CarDealer.Repositorys
{
    public class CustomerRepository : Repo<CustomerEntity>
    {
        public CustomerRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
