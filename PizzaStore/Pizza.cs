using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Pizza
    {
        // instance fields
        private double _price;
        private string _name;
        private string _menuId;
        private bool _family;
        private List<Topping> _toppings;
        private bool _deepPan;
        private bool _glutenFree;
        private bool _onMenu;

        public Pizza(double price, string name, string menuId, bool family, List<Topping> toppings, bool deepPan, bool glutenFree, bool onMenu)
        {
            _price = price;
            _name = name;
            _menuId = menuId;
            _family = family;
            _toppings = toppings;
            // this constructor is only called by the employee, to create a new pizza template (eg pepperoni pizza)
            _deepPan = deepPan;
            _glutenFree = glutenFree;
            _onMenu = onMenu;
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string MenuID
        {
            get { return _menuId; }
            set
            {
                if (value != _menuId)
                {
                    _menuId = value;
                }
            }
        }
        public bool Family
        {
            get { return _family; }
            set { _family = value; }
        }
        public List<Topping> Toppings
        {
            get { return _toppings; }
            set { _toppings = value; }
        }

        public bool DeepPan
        {
            get { return _deepPan; }
            set { _deepPan = value; }
        }
        public bool GlutenFree
        {
            get { return _glutenFree; }
            set { _glutenFree = value; }
        }
        public bool OnMenu
        {
            get { return _onMenu; }
            set { _onMenu = value; }
        }
        // methods

        public override string ToString()
        {

            return $"\tPizza Name: {_name}, Price: {_price}, MenuID: {_menuId}, Family Sized: {_family}, Deep Pan: {_deepPan}, Gluten Free: {_glutenFree}, Is it on the menu?: {_onMenu}\n" +
                   $"\tPizza Toppings: {Topping.ToppingsListToString(_toppings)}";
        }
    }
}
