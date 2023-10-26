using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Topping
    {
        // instance fields
        private double _price;
        private string _name;
        private bool _onMenu;
        private int _id = 0;
        private static int _counter = 0;

        // constructor

        public Topping(double price, string name, bool onMenu) 
        {
           // constructor for when the template is created
            _counter++;
            _id = _counter;
            _price = price;
            _name = name;
            _onMenu = onMenu;
        }
        //public Toppings(Toppings top)
        //{
        //    // called when the template is copied to a new object
        //    _id = top._id;
        //    _price = top._price;
        //    _name = top._name;
        //    _onMenu = top._onMenu;
        //}


        // properties
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
        public bool OnMenu
        {
            get { return _onMenu; }
            set { _onMenu = value; }
        }
        public int ID
        {
            get { return _id; }
        }
        // methods
        public override string ToString()
        {
            return $"Name: {_name}, Price: {_price}, ID: {_id} Is it on the menu?: {(_onMenu == true ? "Yes" : "No")}";
        }
        public static string ToppingsListToString(List<Topping> obj)
        {
            string toppingsString = "";
            for (int count = 1; count <= obj.Count; count++)
            {
                if (count == obj.Count)
                {
                    toppingsString += obj[count - 1].Name;
                }
                else
                {
                    toppingsString += obj[count - 1].Name + ", ";
                }
            }
            return toppingsString;
        }
    }
}
