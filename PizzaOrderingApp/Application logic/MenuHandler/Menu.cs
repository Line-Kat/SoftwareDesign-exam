﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.MenuHandler
{
    public abstract class Menu
    {
        //fjerne?

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual string Description { get; set; }

        protected string Divider = "~~~~~~~~~~~~~~~~~~~~~~";

        //Abstrakt metode så alle menyene bruker for å printe ut
        public abstract void PrintMenu();
      

    }
}
