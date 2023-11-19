using CarDealer.Models;

namespace CarDealer.Menus;

public class AddCarMenu
{
    public static CarRegistrationForm AddCar()
    {
        var car = new CarRegistrationForm();
        Console.Write("Print car Maker: ");
        car.Maker = Console.ReadLine()!;
        Console.Write("Print car Model: ");
        car.Model = Console.ReadLine()!;
        Console.Write("Print car regnumber (xxx111): ");
        car.RegNumber = Console.ReadLine()!;
        Console.Write("Print car Year: ");
        car.ModelYear = Console.ReadLine()!;
        Console.Write("Print car Fuel: ");
        car.Fuel = Console.ReadLine()!;
        Console.Write("Print milage in km: ");
        car.Milage = Console.ReadLine()!;
        Console.Write("Print car Condition (1-5): ");
        car.Condition = Console.ReadLine()!;
        Console.Write("Print car Color: ");
        car.Color = Console.ReadLine()!;
        Console.Write("Print car Gearbox: ");
        car.Gearbox = Console.ReadLine()!;

        return car;
    }

    
}
