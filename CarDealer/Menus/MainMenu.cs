using System.Diagnostics;

namespace CarDealer.Menus
{
    public class MainMenu
    {
        private readonly CarMenu _carMenu;

        public MainMenu(CarMenu carMenu)
        {
            _carMenu = carMenu;
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
                    Console.Write("Make your choice: ");
                    var userOption = Console.ReadLine();

                    switch (userOption)
                    {
                        case "1":
                            await _carMenu.ShowMenu();
                                break;
                    }

                } while (true);

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }
    }
}

