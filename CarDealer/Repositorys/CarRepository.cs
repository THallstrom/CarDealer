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

    //public override Task<bool> ExistAsync(Expression<Func<CarEntity, bool>> expression)
    //{
    //    return true .Where IsSold = true;
    //}

    public override async Task<IEnumerable<CarEntity>> GetAllAsync()
    {
        return await _context.Car
            .Include(x => x.Maker)
            .Include(x => x.Model)
            .ToListAsync();        
    }

    public override async Task<IEnumerable<CarEntity>> GetAllNotSoldAsync()
    {
        return await _context.Car
            .Include(x => x.Maker)
            .Include(x => x.Model)
            .Where(x => x.IsSold == false)
            .ToListAsync();
    }

    
}
