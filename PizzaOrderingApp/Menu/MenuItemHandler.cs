﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Menu
{

	public class MenuItemHandler
	{
		private readonly PizzaOrderingDbContext dbContext;

		public MenuItemHandler(PizzaOrderingDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void AddProduct(MenuItem product)
		{
			if (product is MenuItem menuItem)
			{
				dbContext.MenuItems.Add(menuItem);
				dbContext.SaveChanges();
			}
			else
			{
				throw new ArgumentException("Product must be the correct type");
			}
		}

		// Legg til en metode for å legge til en pizza i en kategori
		public void AddPizzaToCategory(string categoryName, string pizzaName, decimal price, string description)
		{
			var category = dbContext.MenuCategories.FirstOrDefault(c => c.CategoryName == categoryName);

			if (category == null)
			{
				Console.WriteLine($"Kategorien '{categoryName}' eksisterer ikke.");
				return;
			}

			var pizza = new MenuItem
			{
				ItemName = pizzaName,
				Price = price,
				Description = description,
				Category = category
			};

			AddProduct(pizza); 
			Console.WriteLine($"Pizza '{pizzaName}' er lagt til i kategorien '{categoryName}'.");
		}
	}
}




