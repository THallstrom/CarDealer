using CarDealer.Entitys;
using CarDealer.Menus;
using CarDealer.Models;
using CarDealer.Repositorys;
using System.Diagnostics;

namespace CarDealer.Services
{
    public class OrderService
    {
        private readonly CarService _carService;
        private readonly CustomerService _customerService;
        private readonly CarRepository _carRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly AddCustomerMenu _addCustomerMenu;
        private readonly OrderRepository _orderReposity;

        public OrderService(CarService carService, CustomerService customerService, CarRepository carRepository, CustomerRepository customerRepository, AddCustomerMenu addCustomerMenu, OrderRepository orderReposity)
        {
            _carService = carService;
            _customerService = customerService;
            _carRepository = carRepository;
            _customerRepository = customerRepository;
            _addCustomerMenu = addCustomerMenu;
            _orderReposity = orderReposity;
        }

        public async Task<CustomerEntity> GetCustomer(CustomerVerificationForm form)
        {
            try
            {
                var customer = (await _customerRepository.GetAsync(x => x.Email == form.Email));
                if (customer == null)
                {
                    var newCustomer = _addCustomerMenu.AddCustomer();
                    if (newCustomer != null)
                    {
                        customer = await _customerService.CreateCustomerAsync(newCustomer);
                        return customer;
                    }
                }
                return customer!;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<CarEntity> GetCar()
        {
            try
            {
                var cars = await _carService.GetAllNotSoldCarsAsync();
                Console.Clear();
                Console.WriteLine("Cars available for sale");
                foreach (var item in cars)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Brand: {item.Maker.Maker} Model: {item.Model.ModelName}");
                    Console.WriteLine($"Reg number: {item.RegNumber}");
                    Console.WriteLine();
                }

                Console.WriteLine("Print regnumber for car that is bought");
                var bought = Console.ReadLine();
                var soldCar = new SoldCar { Regnumber = bought!.ToString() };
                var CarIsSold = await _carService.SoldCarAsync(soldCar);
                return CarIsSold;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<OrderEntity> CreateOrderAsync(CustomerEntity customer, CarEntity car)
        {
            try
            {

                var order = new OrderEntity { Customer = customer, Car = car };
                var customerCar = await _orderReposity.CreateAsync(order);
                return customerCar;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<IEnumerable<OrderEntity>> GetOrder()
        {
            try
            {
                var order = await _orderReposity.GetAllAsync();
                return order ?? null!;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task <bool> RemoveOrder(RemoveId form)
        {
            var removedOrder = await _orderReposity.GetAsync(x => x.Id == form.Id);
            if (removedOrder != null)
            {
                return await _orderReposity.DeleteAsync(removedOrder);
            }
            return false;
        }
    }
}
