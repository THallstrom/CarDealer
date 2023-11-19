using CarDealer.Models;
using CarDealer.Repositorys;
using CarDealer.Services;
using System.Diagnostics;

namespace CarDealer.Menus;

public class OrderMenu
{
    private readonly CarService _carService;
    private readonly CustomerService _customerService;
    private readonly OrderService _orderService;
    private readonly CarRepository _carRepository;
    private readonly CustomerRepository _customerRepository;


    public OrderMenu(CarService carService, CustomerService customerService, CarRepository carRepository, CustomerRepository customerRepository, OrderService orderService)
    {
        _carService = carService;
        _customerService = customerService;
        _carRepository = carRepository;
        _customerRepository = customerRepository;
        _orderService = orderService;
    }

    public async Task ShowMenu()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Hallström Car Dealer");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Make Order");
            Console.WriteLine("2. Read Order");
            Console.WriteLine("3. Remove Order");
            Console.Write("Make your choice: ");
            var userOption = Console.ReadLine();

            switch (userOption)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Registered as customer");
                    var customerList = await _customerRepository.GetAllAsync();
                    foreach (var custom in customerList)
                    {
                        Console.WriteLine($"{custom.FirstName} {custom.LastName}");
                        Console.WriteLine();
                    }
                    var customerVerificationform = new CustomerVerificationForm();
                    Console.WriteLine("Choose customer by Name");
                    Console.Write("Firstname: ");
                    customerVerificationform.FirstName = Console.ReadLine()!;
                    Console.Write("Lastname: ");
                    customerVerificationform.LastName = Console.ReadLine()!;
                    Console.Write("Email: ");
                    customerVerificationform.Email = Console.ReadLine()!;

                    var customer = await _orderService.GetCustomer(customerVerificationform);
                    var car = await _orderService.GetCar();
                    var order = await _orderService.CreateOrderAsync(customer, car);
                    if (order != null)
                    {
                        Console.Clear();
                        Console.WriteLine($"Ordernr: {order.Id}");
                        Console.WriteLine($"Buyer: {order.Customer.FirstName} {order.Customer.LastName}");
                        Console.WriteLine($"Car: {order.Car.Maker.Maker} {order.Car.Model.ModelName}");
                        Console.WriteLine($"Regnummer: {order.Car.RegNumber}");
                        Console.WriteLine($"Fuel: {order.Car.Fuel.FuelType}");
                        Console.WriteLine($"GearBok: {order.Car.GearBox.GearboxType}");
                    }
                    else
                        Console.WriteLine("Not able to locate car please try again");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Orders in progress");
                    Console.WriteLine("------------------");
                    var orders = await _orderService.GetOrder();
                    if (orders != null)
                    {
                        foreach (var madeorder in orders)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Order number {madeorder.Id}");
                            Console.WriteLine($"Customer: {madeorder.Customer.FirstName} {madeorder.Customer.LastName}");
                            Console.WriteLine($"Car: {madeorder.Car.Maker.Maker} {madeorder.Car.Model.ModelName}");
                            Console.WriteLine($"Reg number: {madeorder.Car.RegNumber} ");
                        }
                        Console.WriteLine("Click to get back to program");
                    }
                    else
                        Console.WriteLine("Orderlist is empty");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Orders to be removed");
                    Console.WriteLine("--------------------");
                    orders = await _orderService.GetOrder();
                    if (orders != null)
                    {
                        foreach (var madeorder in orders)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Order number {madeorder.Id}");
                            Console.WriteLine($"Customer: {madeorder.Customer.FirstName} {madeorder.Customer.LastName}");
                            Console.WriteLine($"Car: {madeorder.Car.Maker.Maker} {madeorder.Car.Model.ModelName}");
                            Console.WriteLine($"Reg number: {madeorder.Car.RegNumber} ");
                        }
                    }
                    else
                        Console.WriteLine("Orderlist is empty");
                    Console.Write("Print Ordernumber to remove: ");
                    var removed = Convert.ToInt32(Console.ReadLine());
                    var removeId = new RemoveId { Id = removed };
                    Console.Clear();
                    Console.WriteLine(( await _orderService.RemoveOrder(removeId)) ? "Order removed Sucsessfully" : "Order not removed");
                    Console.ReadLine();
                    break;
                default: break;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

}



