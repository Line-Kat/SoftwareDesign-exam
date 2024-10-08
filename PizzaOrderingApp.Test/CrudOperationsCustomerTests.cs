﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.Technical_services;

namespace PizzaOrderingApp.Test {
	public class CrudOperationsCustomerTests {


		[Test]
		public void AddCustomer_AddingCustomerToDb_ReturnsCustomer() {
			//Arrange
			CrudOperationsCustomer crudOperationsCustomer = new();
			string expectedName = "Dutleif";

			//Act
			Customer customer = crudOperationsCustomer.AddCustomer(new() { CustomerName = "Dutleif" });
			string actualName = customer.CustomerName;

			//Assert
			Assert.That(actualName, Is.EqualTo(expectedName));
		}

		[Test]
		public void GetCustomerByPhoneNr_GettingCustomerByPhoneNumber_ReturnCustomer() {
			//Arrange
			CrudOperationsCustomer crudOperationsCustomer = new();
			Customer expectedCustomer = new() { CustomerName = "Sandra", PhoneNr = 87654321 };
			crudOperationsCustomer.AddCustomer(expectedCustomer);

			//Act
			Customer actualCustomer = crudOperationsCustomer.GetCustomerByPhoneNr(expectedCustomer.PhoneNr);

			//Assert
			Assert.That(expectedCustomer.PhoneNr, Is.EqualTo(actualCustomer.PhoneNr));
		}
	}
}
