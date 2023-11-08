﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp
{
    public abstract class Menu
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual string Description { get; set; }

        //Abstrakt metode så alle menyene bruker for å printe ut deres meny
        public abstract void PrintMenu();

    }
}
