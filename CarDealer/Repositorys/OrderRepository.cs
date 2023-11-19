using CarDealer.Contexts;
using CarDealer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Repositorys;

public class OrderRepository : Repo<OrderEntity>
{
    private readonly DataContext _context;
    public OrderRepository(DataContext dataContext) : base(dataContext)
    {
        _context = dataContext;
    }

    public override async Task<IEnumerable<OrderEntity>> GetAllAsync()
    {
        return await _context.Order
            .Include(x => x.Car)
            .ThenInclude(x => x.Maker)
            .Include(x => x.Car)
            .ThenInclude(x => x.Model)
            .Include(x => x.Customer)            
            .ToListAsync();
    }
}
