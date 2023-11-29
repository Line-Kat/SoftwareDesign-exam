using PizzaOrderingApp.Application_logic.CartHandler;
using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Application_logic.MenuHandler;
using PizzaOrderingApp.Application_logic.MenuHandler.Decorators;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.MenuHandler;

namespace PizzaOrderingApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
	
			//Metode som legger til pizza i pizza tabellen i db (om de ikke finnes fra før av)
			AddMenuItems addMenuItems = new();
			addMenuItems.AddItems();

			Console.WriteLine("Welcome to Pizza Factory");
			HandleCustomer handleCustomer = new();
			HandleOrder handleOrder = new();
			DisplayMenus displayMenus = new();
			ShoppingCart shoppingCart = new ShoppingCart();
			PizzaToppingSelectionHandler toppingHandler = new PizzaToppingSelectionHandler();
			IPizza finalPizza = toppingHandler.GetFinalPizza();
			CartMenu cartMenu = new CartMenu(shoppingCart, displayMenus, toppingHandler);

			Login login = new Login();
			Customer customer = login.UserLogin();

			Console.WriteLine($"Welcome {customer.CustomerName}");

			bool keepRunning = true;
			while (keepRunning) {
				Console.WriteLine("Choose an option:\n1 Order pizza\n2 Log out\n3 Edit your user\n4 Delete your user");

				string? userInput = Console.ReadLine();
				if (userInput.Equals("1"))
				{
					HandleOrder order = new();
					PizzaQueue queue = new();

					cartMenu.ShowMenu();

					//int numberOfPizzas= handleOrder.GetNumberOfItems();

					int totalNumberOfPizzas = shoppingCart.totalNumberOfPizzas();
					
					DateTime dateTime = queue.CheckQueue(totalNumberOfPizzas);
					order.PrintOrder(customer, dateTime, totalNumberOfPizzas);
					order.AddOrder(customer);

					keepRunning = false;
				}

				if (userInput.Equals("2")) {
					Console.WriteLine("Thank you for visiting us. Welcome back!");
					keepRunning = false;
				}

				if (userInput.Equals("3")) {
					handleCustomer.DeleteCustomer(customer.CustomerId);
					Console.WriteLine("You are now deleted from out database. You are welcome to come back another time");
					keepRunning = false;
				}
			}
		}
	}
}