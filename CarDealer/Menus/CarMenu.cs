using CarDealer.Models;
using CarDealer.Services;
using System.Diagnostics;

namespace CarDealer.Menus
{
    public class CarMenu
    {
        private readonly AddCarMenu _addCarMenu;
        private readonly CarService _carService;

        public CarMenu(AddCarMenu addCarMenu, CarService carService)
        {
            _addCarMenu = addCarMenu;
            _carService = carService;
        }

        public async Task ShowMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Hallström Car Dealer");
                Console.WriteLine("--------------------");
                Console.WriteLine("1. Add Car");
                Console.WriteLine("2. Read Cars");
                Console.WriteLine("3. Update Car");
                Console.WriteLine("4. Sold Car");
                Console.WriteLine("5. Delete Car");
                Console.Write("Make your choice: ");
                var userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        var car = _addCarMenu.AddCar();
                        var entity = await _carService.AddCarAsync(car);
                        if (entity != null)
                        {
                            Console.Clear();
                            Console.WriteLine("New car in database");
                            Console.WriteLine($"Maker: {entity.Maker.Maker}");
                            Console.WriteLine($"Model: {entity.Model.ModelName}");
                            Console.WriteLine($"Reg number: {entity.RegNumber}");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Bilen finns redan i systemet");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        await GetCars();
                        Console.WriteLine("Click to get back to program");
                        Console.ReadLine();
                        break;
                    case "3":
                        await GetCars();
                        var carsUpdate = new CarUpdateForm();
                        Console.Write("Reg number on car you would like to change: ");
                        carsUpdate.RegNumber = Console.ReadLine()!;
                        Console.Write("New milage: ");
                        carsUpdate.Milage = Console.ReadLine();
                        Console.Write("New Condition: ");
                        carsUpdate.Condition = Console.ReadLine();
                        Console.Write("Is sold (Y/N): ");
                        var sold = Console.ReadLine();
                        if (sold == "Y")
                            carsUpdate.IsSold = true;
                        else
                            carsUpdate.IsSold = false;
                        entity = await _carService.UpdateCarAsync(carsUpdate);
                        if (entity != null)
                        {
                            Console.WriteLine($"Brand and model: {entity.Maker.Maker} {entity.Model.ModelName}");
                            Console.WriteLine($"Condition: {entity.Condition.ConditionGrade}");
                            Console.WriteLine($"Milage: {entity.Milage}");
                            Console.ReadLine();
                        }
                        else
                            Console.WriteLine("Something went Wrong");
                        break;
                    case "4":
                        await GetCars();
                        var soldCarNumber = new SoldCar();
                        Console.Write("Input sold cars regnumber: ");
                        soldCarNumber.Regnumber = Console.ReadLine()!;
                        var soldcar = await _carService.SoldCarAsync(soldCarNumber);
                        if (soldcar != null)
                        {
                            Console.Clear();
                            Console.WriteLine($"Brand: {soldcar.Maker.Maker}");
                            Console.WriteLine($"Model: {soldcar.Model.ModelName}");
                            Console.WriteLine($"Reg number: {soldcar.RegNumber}");
                            Console.WriteLine("This car is sold");
                        }
                        else
                            Console.WriteLine("Not posible to find car");
                        Console.ReadLine();
                        break;
                    case "5":
                        await GetCars();
                        var deleteCarNumber = new SoldCar();
                        Console.Clear();
                        Console.Write("Input sold cars regnumber: ");
                        deleteCarNumber.Regnumber = Console.ReadLine()!;
                        Console.WriteLine(await _carService.DeleteCarAsync(deleteCarNumber) ? "Car is removed from database" : "Not posible to remove car"); Console.ReadLine();
                        break;
                    case "6":
                        var cars = await _carService.GetAllCarsAsync();
                        if (cars != null)
                        {
                            Console.Clear();
                            foreach (var cart in cars)
                            {
                                Console.WriteLine($"Brand: {cart.Maker.Maker}");
                                Console.WriteLine($"Model: {cart.Model.ModelName}");
                                Console.WriteLine($"Reg number: {cart.RegNumber}");
                                Console.WriteLine();
                            }
                            Console.WriteLine("Click to return to program");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Systemet är tyvärr tomt");
                            Thread.Sleep(2000);
                        }
                        break;
                    default: break;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }

        public async Task GetCars()
        {
            var cars = await _carService.GetAllNotSoldCarsAsync();
            if (cars != null)
            {
                Console.Clear();
                foreach (var cart in cars)
                {
                    Console.WriteLine($"Brand: {cart.Maker.Maker}");
                    Console.WriteLine($"Model: {cart.Model.ModelName}");
                    Console.WriteLine($"Reg number: {cart.RegNumber}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Systemet är tyvärr tomt");
                Thread.Sleep(2000);
            }
        }
    }
}
