using CarDealer.Models;
using System.Diagnostics;

namespace CarDealer.Menus
{
    public class AddCustomerMenu
    {
        public CustomerRegistrationForm AddCustomer()
        {
            try
            {
                var customerRegistrationForm = new CustomerRegistrationForm();
                Console.Clear();
                Console.WriteLine("Customer Registration");
                Console.WriteLine("---------------------");
                Console.Write("Print Firstname: ");
                customerRegistrationForm.FirstName = Console.ReadLine()!;
                Console.Write("Print Lastname: ");
                customerRegistrationForm.LastName = Console.ReadLine()!;
                Console.Write("Print Email: ");
                customerRegistrationForm.Email = Console.ReadLine()!;
                Console.Write("Print Streetaddress: ");
                customerRegistrationForm.StreetAddress = Console.ReadLine()!;
                Console.Write("Print PostalCode: ");
                customerRegistrationForm.PostalCode = Console.ReadLine()!;
                Console.Write("Print City: ");
                customerRegistrationForm.City = Console.ReadLine()!;
                return customerRegistrationForm;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;

        }

    }

};