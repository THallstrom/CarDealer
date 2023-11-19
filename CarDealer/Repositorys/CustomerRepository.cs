using CarDealer.Contexts;
using CarDealer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Repositorys
{
    public class CustomerRepository : Repo<CustomerEntity>
            {
        private readonly DataContext _context;
        public CustomerRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }

        public override async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            return await _context.Customer
                .Include(x => x.Address)
                .ToListAsync();
        }

        
    }
}
