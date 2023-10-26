using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public static class ToppingRepository
    {
        // instance fields
        private static Dictionary<int, Topping> _toppings;


        //properties
        public static int Count { get { return _toppings.Count; } }

        public static Dictionary<int, Topping> Toppings
        {
            get { return _toppings; }
        }


        //constructor
        static ToppingRepository()
        {
            _toppings = new Dictionary<int, Topping>();
        }

        // methods
        public static bool AddTopping(Topping aTopping)
        {
            if (!_toppings.ContainsKey(aTopping.ID))
            {
                _toppings.Add(aTopping.ID, aTopping);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DeleteTopping(Topping aTopping)
        {
            bool sucess = _toppings.Remove(aTopping.ID);
            return sucess;
        }
        public static bool UpdateByID(int ID, Topping aTopping)
        {
            if (_toppings.ContainsKey(ID))
            {
                _toppings[ID].Price = aTopping.Price;
                _toppings[ID].Name = aTopping.Name;
                _toppings[ID].OnMenu = aTopping.OnMenu;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool UpdateByObject(Topping existingTopping, Topping newTopping)
        {
            if (_toppings.ContainsValue(existingTopping))
            {
                UpdateByID(existingTopping.ID, newTopping);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<Topping> SearchName(string name)
        {
            List<Topping> result = new List<Topping>();
            foreach (Topping aTopping in _toppings.Values)
            {
                if (aTopping.Name == name)
                {
                    result.Add(aTopping);
                }
            }
            return result;
        }
    }
}
