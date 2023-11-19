using CarDealer.Entitys;
using CarDealer.Models;

namespace CarDealer.Menus
{
    public class AddCustomerMenu
    {
        public static CustomerRegistrationForm AddCustomer()
        {
            CustomerEntity customerEntity = new CustomerEntity();
            Console.Clear();
            Console.WriteLine("Customer Registration");
            Console.WriteLine("---------------------");
            Console.Write("Print Firstname: ");
            customerEntity.FirstName = Console.ReadLine()!;
            Console.Write("Print Lastname: ");
            customerEntity.LastName = Console.ReadLine()!;
            Console.Write("Print Email: ");
            customerEntity.Email = Console.ReadLine()!.Trim();
            customerEntity.Address = new AddressEntity()
            {
            Console.Write("Print Streetaddress: ");
            customerEntity.Address.StreetName = Console.ReadLine()!;
            Console.Write("Print PostalCode: ");
            customerEntity.Address.PostalCode = Console.ReadLine()!;
            Console.Write("Print City: ");
            customerEntity.Address.City = Console.ReadLine()!;
        }
            return customerEntity;
        }
    }
};