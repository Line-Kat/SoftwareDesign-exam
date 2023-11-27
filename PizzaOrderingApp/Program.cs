using PizzaOrderingApp.Application_logic.MenuHandler;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.MenuHandler;

namespace PizzaOrderingApp
{
	internal class Program
	{
		static void Main(string[] args)
		{

			/*

			
			// Metode som legger til pizza i pizza tabellen i db (om de ikke finnes fra før av)
			AddMenuItems addMenuItems = new AddMenuItems();
			addMenuItems.AddItems();

			// Displaye menyene

			DisplayMenus displayMenus = new DisplayMenus();
			displayMenus.PrintMenu();

			*/

			Console.WriteLine("Welcome to Pizza Factory");
			HandleCustomer handleCustomer = new();
			HandleOrder handleOrder = new();
			DisplayMenus displayMenus = new();

			Login login = new Login();
			Customer customer = login.UserLogin();

			Console.WriteLine($"Welcome {customer.CustomerName}");

			bool keepRunning = true;
			while (keepRunning) {
				Console.WriteLine("\nChoose an option:\n1 Order pizza\n2 Log out\n3 Manage User");

				string? userInput = Console.ReadLine();
				if (userInput.Equals("1"))
				{
					HandleOrder order = new();
					PizzaQueue queue = new();

					displayMenus.PrintMenu();
					DateTime dateTime = queue.CheckQueue(handleOrder.GetNumberOfItems());
					order.PrintOrder(customer, dateTime);
					order.AddOrder(customer);

					keepRunning = false;
				}

				if (userInput.Equals("2"))
				{
					Console.WriteLine("Thank you for visiting us. Welcome back!");
					keepRunning = false;
				}

				if (userInput.Equals("3")) {
					
					bool keepRunning2 = true;
					while (keepRunning2) {

						Console.WriteLine("\nManage your account:\n1 Edit your user \n2 Delete user");
						string? userInput2 = Console.ReadLine();
						if (userInput2.Equals("1")) {
							handleCustomer.ConfirmAddCustomer(customer);
							keepRunning2 = false;
						}

						if (userInput2.Equals("2")) {
							handleCustomer.DeleteCustomer(customer.CustomerId);
							Console.WriteLine("You are now deleted from out database. You are welcome to come back another time");
							keepRunning2 = false;
						}

					}
				}
				

			}
		}
	}
}