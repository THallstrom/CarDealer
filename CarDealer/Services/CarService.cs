using CarDealer.Entitys;
using CarDealer.Models;
using CarDealer.Repositorys;
using System.Diagnostics;

namespace CarDealer.Services;

public class CarService
{
    private readonly CarRepository _carRepository;
    private readonly ColorRepository _colorRepository;
    private readonly FuelRepository _fuelRepository;
    private readonly GearBoxRepository _gearBoxRepository;
    private readonly MakerRepository _makerRepository;
    private readonly YearRepository _yearRepository;
    private readonly ModelRepository _modelRepository;
    private readonly ConditionRepository _conditionRepository;

    public CarService(CarRepository carRepository, ColorRepository colorRepository, FuelRepository fuelRepository, GearBoxRepository gearBoxRepository, MakerRepository makerRepository, YearRepository yearRepository, ModelRepository modelRepository, ConditionRepository conditionRepository)
    {
        _carRepository = carRepository;
        _colorRepository = colorRepository;
        _fuelRepository = fuelRepository;
        _gearBoxRepository = gearBoxRepository;
        _makerRepository = makerRepository;
        _yearRepository = yearRepository;
        _modelRepository = modelRepository;
        _conditionRepository = conditionRepository;
    }

    public async Task<CarEntity> AddCarAsync(CarRegistrationForm form)
    {
        if (!await _carRepository.ExistAsync(x => x.RegNumber == form.RegNumber))
        {
            var condition = await _conditionRepository.GetAsync(x => x.ConditionGrade == form.Condition);
            if (condition == null)
                condition = await _conditionRepository.CreateAsync(new ConditionEntity { ConditionGrade = form.Condition });
            var model = await _modelRepository.GetAsync(x => x.ModelName == form.Model);
            if (model == null)
                model = await _modelRepository.CreateAsync(new ModelEntity { ModelName = form.Model });
            var maker = await _makerRepository.GetAsync(x => x.Maker == form.Maker);
            if (maker == null)
                maker = await _makerRepository.CreateAsync(new MakerEntity { Maker = form.Maker });
            var color = await _colorRepository.GetAsync(x => x.Color == form.Color);
            if (color == null)
                color = await _colorRepository.CreateAsync(new ColorEntity { Color = form.Color });
            var gearBox = await _gearBoxRepository.GetAsync(x => x.GearboxType == form.Gearbox);
            if (gearBox == null)
                gearBox = await _gearBoxRepository.CreateAsync(new GearBoxEntity { GearboxType = form.Gearbox });
            var fuel = await _fuelRepository.GetAsync(x => x.FuelType == form.Fuel);
            if (fuel == null)
                fuel = await _fuelRepository.CreateAsync(new FuelEntity { FuelType = form.Fuel });
            var year = await _yearRepository.GetAsync(x => x.Year == form.ModelYear);
            if (year == null)
                year = await _yearRepository.CreateAsync(new YearEntity { Year = form.ModelYear });
            var car = await _carRepository.CreateAsync(new CarEntity
            {
                IsSold = false,
                RegNumber = form.RegNumber,
                Condition = condition!,
                Milage = form.Milage,
                Model = model!,
                Maker = maker!,
                Color = color!,
                GearBox = gearBox!,
                Fuel = fuel!,
                Year = year!,
            });
            return car;
        }
        return null!;
    }

    public async Task<IEnumerable<CarEntity>> GetAllCars()
    {
        try
        {
            var cars = await _carRepository.GetAllAsync();
            return cars.Any() ? cars : null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public async Task<IEnumerable<CarEntity>> GetAllNotSoldCars()
    {
        try
        {
            var cars = await _carRepository.GetAllNotSoldAsync();
            return cars.Any() ? cars : null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public async Task<CarEntity> UpdateCarAsync(CarUpdateForm form)
    {
        var entity = await _carRepository.GetAsync(x => x.RegNumber == form.RegNumber);
        if (entity != null)
        {
            if (form.Milage != string.Empty!)
                entity.Milage = form.Milage!;
            if (form.IsSold != false)
                entity.IsSold = form.IsSold;
            var cond = await _conditionRepository.GetAsync(x => x.Id == entity.ConditionId);
            if (cond != null)
            {
                if (form.Condition != string.Empty!)
                    cond.ConditionGrade = form.Condition!;
                cond = await _conditionRepository.UpdateAsync(cond!);
            }
            entity = await _carRepository.UpdateAsync(entity);
            return entity ?? null!;
        }
        return null!;
    }
    public async Task<CarEntity> SoldCarAsync(SoldCar soldCar)
    {
        try
        {
            if (await _carRepository.ExistAsync(x => x.RegNumber == soldCar.Regnumber && x.IsSold == false))
            {
                var entity = await _carRepository.GetAsync(x => x.RegNumber == soldCar.Regnumber);
                if (entity != null)
                {
                    entity.IsSold = true;
                    await _carRepository.UpdateAsync(entity);
                    return entity ?? null!;
                }
                return null!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public async Task<bool> DeleteCarAsync(SoldCar soldCar)
    {
        try
        {
            var entity = await _carRepository.GetAsync(x => x.RegNumber == soldCar.Regnumber);
            if (entity != null)
            {
                await _carRepository.DeleteAsync(entity);
                return true;
            }
            return false;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
