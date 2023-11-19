using System.Diagnostics;

namespace CarDealer.Menus
{
    public class CustomerMenu
    {
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
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
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
    }
}

