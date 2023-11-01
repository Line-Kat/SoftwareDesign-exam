﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Menu
{
	internal class MenuCategoryManager
	{

		private readonly PizzaOrderingDbContext dbContext;

		public MenuCategoryManager(PizzaOrderingDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void CreateMenuCategory(string categoryName)
		{
			// Se om "kategorien" finnes i db
			if (dbContext.MenuCategories.Any(c => c.CategoryName == categoryName))
			{
				Console.WriteLine($"Kategorien '{categoryName}' eksisterer allerede.");
				return;
			}

			var newCategory = new MenuCategory
			{
				CategoryName = categoryName
			};

			dbContext.MenuCategories.Add(newCategory);
			dbContext.SaveChanges();

			Console.WriteLine($"Kategorien '{categoryName}' er opprettet.");
		}
	}
}
