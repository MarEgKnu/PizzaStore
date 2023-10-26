using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public static class MenuCatalog
    {

        // instance fields
        private static Dictionary<string, Pizza> _pizzas;


        //properties
        public static int Count { get { return _pizzas.Count; } }
        public static Dictionary<string, Pizza> Pizzas {  get { return _pizzas; } }


        //constructor
        static MenuCatalog()
        {
            _pizzas = new Dictionary<string, Pizza>();
        }

        // methods

        public static bool AddItem(Pizza aPizza)
        {
            if (!_pizzas.ContainsKey(aPizza.MenuID))
            {
                _pizzas.Add(aPizza.MenuID, aPizza);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DoesMenuIdExist(string id)
        {
            if (_pizzas.ContainsKey(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteItem(Pizza aPizza)
        {
            bool sucess = _pizzas.Remove(aPizza.MenuID);
            return sucess;
        }
        public static bool UpdateByID(string menuID, Pizza aPizza)
        {
            if (_pizzas.ContainsKey(menuID))
            {
                // all relavent object vars
                _pizzas[menuID] = aPizza;
                _pizzas[menuID].Name = aPizza.Name;
                _pizzas[menuID].Family = aPizza.Family;
                _pizzas[menuID].Toppings = aPizza.Toppings;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool UpdateByObject(Pizza existingPizza, Pizza newPizza)
        {
            if (_pizzas.ContainsValue(existingPizza))
            {
                UpdateByID(existingPizza.MenuID, newPizza);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool UpdateMenuID(string oldID, string newID) // updates menuID of a pizza
        {
            if (_pizzas.ContainsKey(oldID) && !_pizzas.ContainsKey(newID))
            {
                // deletes the old dictionary entry, and creates a new identical one with a new key
                Pizza existingPizza = _pizzas[oldID];
                _pizzas.Remove(oldID);
                existingPizza.MenuID = newID;
                _pizzas.Add(existingPizza.MenuID, existingPizza);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Pizza? GetPizzaByID(string ID)
        {
            if (_pizzas.ContainsKey(ID))
            {
                return _pizzas[ID];
            }
            else
            {
                return null;
            }
        }
        public static void PrintMenu()
        {
            Console.WriteLine("Menu:");
            foreach (Pizza pizza in _pizzas.Values)
            {
                if (pizza.OnMenu)
                {
                    Console.WriteLine($"{pizza.MenuID}: {pizza.Name}, price: {pizza.Price}, Toppings: {Topping.ToppingsListToString(pizza.Toppings)}");
                }
            }
        }
    }
}
