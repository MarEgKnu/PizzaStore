using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaStore
{
    public class Employee
    {
        // instance fields
        private string _name;
        private int _id;
        private static int _counter = 0;

        //constructor

        public Employee(string name)
        {
            _name = name;
            _counter++;
            _id = _counter;
        }

        // properties
        public string Name 
        { 
            get { return _name; } 
            set { _name = value; }
        }
        public int ID
        {
            get { return _id; }
        }
        // methods
        //public Pizza AddPizza(double price, string name, string menuId, bool family, List<Topping> toppings, bool deepPan, bool glutenFree, bool onMenu)
        //{
        //    // returns pizza menu item
        //    return new Pizza(price, name, menuId, family, toppings, deepPan, glutenFree, onMenu);
        //}
        //public Topping AddToppings(double price, string name, bool onMenu)
        //{
        //    return new Topping(price, name, onMenu);
        //}
        //public void RemovePizza(Pizza? pizza)
        //{
        //    pizza = null;
        //}
        public override string ToString()
        {
            return $"Name: {_name}, ID: {ID}";
        }
    }
}
