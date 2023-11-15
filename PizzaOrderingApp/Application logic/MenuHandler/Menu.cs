﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.MenuHandler
{
    public abstract class Menu
    {
      
        protected string Divider = "~~~~~~~~~~~~~~~~~~~~~~";

        //Abstrakt metode så alle menyene bruker for å printe ut
        public abstract void PrintMenu();
      

    }
}
