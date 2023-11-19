using CarDealer.Models;
using CarDealer.Services;
using System.Diagnostics;

namespace CarDealer.Menus;

public class CustomerMenu
{
    private readonly AddCustomerMenu _addCustomerMenu;
    private readonly CustomerService _customerService;

    public CustomerMenu(AddCustomerMenu addCustomerMenu, CustomerService customerService)
    {
        _addCustomerMenu = addCustomerMenu;
        _customerService = customerService;
    }

    public async Task ShowMenu()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Hallström Car Dealer");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Read Customers");
            Console.WriteLine("3. Update Customer");
            Console.WriteLine("4. Remove Customer");
            Console.Write("Make your choice: ");
            var userOption = Console.ReadLine();

            switch (userOption)
            {
                case "1":
                    var customer = _addCustomerMenu.AddCustomer();
                    var entity = _customerService.CreateCustomerAsync(customer);
                    if (entity != null)
                    {
                        Console.WriteLine("New customer in database");
                        Console.WriteLine("------------------------");
                        Console.WriteLine($"Customer name: {entity}");
                    }
                    break;
                case "2":
                    await GetAllCustomers();
                    Console.ReadLine();
                    break;
                case "3":
                    await GetAllCustomers();
                    var updateCustomer = new CustomerUpdateForm();
                    Console.Write("Print FirstName: ");
                    updateCustomer.FirstName = Console.ReadLine()!;
                    Console.Write("Print LastName: ");
                    updateCustomer.LastName = Console.ReadLine()!;
                    Console.Write("Print Email: ");
                    updateCustomer.Email = Console.ReadLine()!;
                    Console.Write("Print Phone: ");
                    updateCustomer.Phone = Console.ReadLine()!;
                    Console.Write("Print Streetname: ");
                    updateCustomer.StreetName = Console.ReadLine()!;
                    Console.Write("Print PostalCode: ");
                    updateCustomer.PostalCode = Console.ReadLine()!;
                    Console.Write("Print City: ");
                    updateCustomer.City = Console.ReadLine()!;
                    var updatedEntity = await _customerService.UpdateAsync(updateCustomer);
                    if (updatedEntity != null)
                    {
                        Console.WriteLine($"{updatedEntity.FirstName} {updatedEntity.LastName}");
                        Console.WriteLine($"{updatedEntity.Email}");
                    }
                    else
                        Console.WriteLine("No update is done...");
                    Console.ReadLine() ;
                    break;
                case "4":
                    await GetAllCustomers();
                    var form = new DeleteCustomerForm();
                    Console.Write("Print Firstname: ");
                    form.FirstName = Console.ReadLine()!;
                    Console.Write("Print Lastname: ");
                    form.LastName = Console.ReadLine()!;
                    Console.Write("Print Email: ");
                    form.Email = Console.ReadLine()!;
                    Console.WriteLine(await _customerService.DeleteCustomerAsync(form) ? "Customer is removed" : "Customer is not removed");
                    Console.ReadLine() ;
                    break;
                case "5":
                    break;
                case "6":
                    break;
                default: break;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }
    public async Task GetAllCustomers()
    {
        var customers = await _customerService.ReadAllCustomerAsync();
        if (customers != null)
        {
            Console.Clear();
            foreach (var person in customers)
            {
                Console.WriteLine($"Customer name: {person.FirstName} {person.LastName}");
                Console.WriteLine($"Customer Address: {person.Address.StreetName}");
                Console.WriteLine();
            }
        }
        else
            Console.WriteLine("Customer database is empty");
    }
}

