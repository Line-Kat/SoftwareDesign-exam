﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PizzaOrderingApp.Entities;

namespace PizzaOrderingApp {
	public class HandleCustomer {
		//method to ask user information questions to console and validate that the user types an input
		//could the validation be moved to fields in the Customer class?
		internal string AskForUserInput(string typeOfInput) {
			string? userInput = null;

			if (typeOfInput == "name") {
				while (string.IsNullOrEmpty(userInput)) {
					Console.WriteLine("Type name: ");
					userInput = Console.ReadLine();
				}
			} else if (typeOfInput == "address") {
				while (string.IsNullOrEmpty(userInput)) {
					Console.WriteLine("Type address: ");
					userInput = Console.ReadLine();
				}
			}
			while (string.IsNullOrEmpty(userInput)) {
				Console.WriteLine("Type phone number (8 digits): ");
				userInput = Console.ReadLine();
			}
			return userInput;
		}

		//previous data in the database dissappears when restarting the program. Why? 
		public void AddCustomer() {

			string inputName = AskForUserInput("name");
			string inputAddress = AskForUserInput("address");
			int inputPhoneNr = Convert.ToInt32(AskForUserInput(""));

			
			Customer customer = new() {
				Name = inputName,
				Address = inputAddress,
				PhoneNr = inputPhoneNr
			};

			//should this be a global object?
			using PizzaOrderingDbContext db = new();

			db.Customer.Add(customer);
			db.SaveChanges();

			//to keep the id of the customer last added to the database
			int latestId = customer.Id;

			Console.WriteLine($"Your information:\nName: {customer.Name}\nAddress: {customer.Address}\nPhone number: {customer.PhoneNr}");

			Console.WriteLine("Is the information correct? (type Y or N)");
			string? userInput = Console.ReadLine();
			if (userInput.ToUpper() == "N") {
				editCustomer(customer.Id);
			} 
		}

		//method that shows the menu for editing customer information
		internal int EditCustomerMenu() {
			Console.WriteLine(
				"Type the number of the alternative you need to edit\n" +
				"1 name\n" +
				"2 address\n" +
				"3 phone number");

			string? userInput = Console.ReadLine();

			if ( (string.IsNullOrEmpty(userInput)) || (Int32.Parse(userInput) < 1) || (Int32.Parse(userInput) > 3) ) {
				Console.WriteLine("You must select one of the alternatives (number 1-3)");
				EditCustomerMenu();
			}


			return Int32.Parse(userInput);
		}

		//edit customers information
		//method must handle the user not typing a value
		public void editCustomer(int id) {
			using PizzaOrderingDbContext db = new();
			Customer? customer = db.Customer.SingleOrDefault(customer => customer.Id == id);

			switch (EditCustomerMenu()) {
				case 1: {
						Console.WriteLine("Type name: ");
						string? name = Console.ReadLine();

						if (customer != null) {
							customer.Name = name;
							db.Update(customer);
							db.SaveChanges();
						}
					}
					break;
				case 2: {
						Console.WriteLine("Type address: ");
						string address = Console.ReadLine();

						if (customer != null) {
							customer.Address = address;
							db.Update(customer);
							db.SaveChanges();
						}
					}
					break;
				case 3: {
					Console.WriteLine("Type phone number");
					int phoneNumber = int.Parse(Console.ReadLine());

					if (customer != null) {
						customer.PhoneNr = phoneNumber;
						db.Update(customer);
						db.SaveChanges();
					}
				}
					break;
			}
		}
	}
}
