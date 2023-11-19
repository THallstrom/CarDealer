using CarDealer.Contexts;
using CarDealer.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarDealer.Repositorys;

public class CarRepository : Repo<CarEntity>
{
    private readonly DataContext _context;
    
    public CarRepository(DataContext dataContext) : base(dataContext)
    {
        _context = dataContext;
    }

        public override async Task<IEnumerable<CarEntity>> GetAllAsync()
    {
        return await _context.Car
            .Include(x => x.Maker)
            .Include(x => x.Model)
            .Include(x=> x.Condition)
            .ToListAsync();        
    }

    public override async Task<IEnumerable<CarEntity>> GetAllNotSoldAsync()
    {
        return await _context.Car
            .Include(x => x.Maker)
            .Include(x => x.Model)
            .Include(x=> x.Condition)
            .Include(x => x.Fuel)
            .Include(x => x.GearBox)
            .Where(x => x.IsSold == false)
            .ToListAsync();
    }

    
}
