using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class OrderLine
    {
        // instance fields
        //private double _price;
        //private string _name;
        //private string _menuId;
        //private bool _family;
        private Pizza _pizza; // can be made more general (menuItem)
        private List<Topping> _extraToppings;
        private List<Topping> _removedToppings; // can be made more general (extraItem)
        //private bool _deepPan;
        //private bool _glutenFree;
        //private bool _onMenu;

        // constructor
        //public Pizza(double price, string name, string menuId, bool family, List<Toppings> toppings, bool deepPan, bool glutenFree, bool onMenu) 
        //{
        //    _price = price;
        //    _name = name;
        //    _menuId = menuId;
        //    _family = family;
        //    _toppings = toppings;
        //    // this constructor is only called by the employee, to create a new pizza template (eg pepperoni pizza)
        //    _defaultToppings = new List<Toppings>(toppings);
        //    _deepPan = deepPan;
        //    _glutenFree = glutenFree;
        //    _onMenu = onMenu;
        //}
        public OrderLine(Pizza pizza)
        {
            // constructor for creating a orderline item WITHOUT any extras
            _pizza = pizza;
            _extraToppings = new List<Topping>();
            _removedToppings = new List<Topping>();
            
            //_price = pizzaTemplate._price;
            //_name = pizzaTemplate._name;
            //MenuID = pizzaTemplate._menuId;
            //_family = pizzaTemplate._family;
            //_toppings = pizzaTemplate._toppings;
            //_defaultToppings = pizzaTemplate._defaultToppings;
            //_deepPan = pizzaTemplate.DeepPan;
            //_glutenFree = pizzaTemplate._glutenFree;
            //_onMenu = pizzaTemplate._onMenu;
        }
        public OrderLine(Pizza pizza, List<Topping> extraToppings, List<Topping> removedToppings)
        {
            // constructor for creating a orderline item WITH already existing extras
            _pizza = pizza;
            _extraToppings = new List<Topping>();
            _removedToppings = new List<Topping>();
            foreach (Topping topping in extraToppings)
            {
                AddTopping(topping);
            }
            foreach (Topping topping in removedToppings)
            {
                RemoveTopping(topping);
            }
        }


        // properties
        //public double Price
        //{
        //    get { return _price; }
        //    set { _price = value; }
        //}
        //public string Name
        //{
        //    get { return _name; }
        //    set { _name = value; }
        //}
        //public string MenuID
        //{
        //    get { return _menuId; }
        //    set { _menuId = value; }
        //}
        //public bool Family
        //{
        //    get { return _family; }
        //    set { _family = value; }
        //}
        public List<Topping> RemovedToppings
        {
            get { return _removedToppings; }
        }
        public List<Topping> ExtraToppings
        {
            get { return _extraToppings; }
        }
        public Pizza MenuItem
        {
            get { return _pizza; }
        }
        //public bool DeepPan
        //{
        //    get { return _deepPan; }
        //    set { _deepPan = value; }
        //}
        //public bool GlutenFree
        //{
        //    get { return _glutenFree; }
        //    set { _glutenFree = value; }
        //}
        //public bool OnMenu
        //{
        //    get { return _onMenu; }
        //    set { _onMenu = value; }
        //}
        // methods
        // returns true if a topping was added, false if it was not added (because it already is)
        public bool AddTopping(Topping topping)
        {
            
            // if the topping isn''t on the menu, is already on the pizza or has already been added, it cannot be added
            if (topping.OnMenu && !_pizza.Toppings.Contains(topping) && !_extraToppings.Contains(topping)) 
            {
                _extraToppings.Add(topping);
                return true;
            }
            else
            {
                return false;
            }
        }
        // returns false if no topping was removed, true if it was
        public bool RemoveTopping(Topping topping) 
        {
            if (_extraToppings.Contains(topping))
            {
                _extraToppings.Remove(topping);
                return true;
            }
            else
            {
                if (_removedToppings.Contains(topping))
                {
                    return false;
                }
                else
                {
                    _removedToppings.Add(topping);
                    return true;
                }
            }
        }

        public double CalculateOrderLinePrice()
        {
            double totalPrice = 0;
            foreach (Topping topping in _extraToppings)
            {
                if (MenuItem.Toppings.Contains(topping))
                {

                    // if the extra topping is already on the pizza, do not add the price to the totalPrice
                }
                else
                {
                    totalPrice = topping.Price + totalPrice;
                    // if the toppings dont match, it was added manually so add price
                }

            }
            totalPrice = MenuItem.Price + totalPrice;
            return totalPrice;
        }

        public override string ToString()
        {

            return $"Item: \n" +
                   $"{_pizza}\n" +
                   $"\tExtra toppings: {Topping.ToppingsListToString(_extraToppings)}\n" +
                   $"\tRemoved toppings: {Topping.ToppingsListToString(_removedToppings)}\n" +
                   $"\tCost: {CalculateOrderLinePrice()}";
        }
    }
}
