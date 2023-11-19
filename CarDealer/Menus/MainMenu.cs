using System.Diagnostics;

namespace CarDealer.Menus
{
    public class MainMenu
    {
        private readonly CarMenu _carMenu;
        private readonly CustomerMenu _customerMenu;
        private readonly OrderMenu _orderMenu;

        public MainMenu(CarMenu carMenu, CustomerMenu customerMenu, OrderMenu orderMenu)
        {
            _carMenu = carMenu;
            _customerMenu = customerMenu;
            _orderMenu = orderMenu;
        }

        public async Task ShowMenu()
        {
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Hallströms Car Dealer");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("1. Cars");
                    Console.WriteLine("2. Customers");
                    Console.WriteLine("3. Order");
                    Console.Write("Make your choice: ");
                    var userOption = Console.ReadLine();

                    switch (userOption)
                    {
                        case "1":
                            await _carMenu.ShowMenu();
                            break;
                        case "2":
                            await _customerMenu.ShowMenu();
                            break;
                        case "3":
                            await _orderMenu.ShowMenu();
                            break;
                    }

                } while (true);

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }
    }
}

