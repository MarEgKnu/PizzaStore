using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Customer
    {
        // instance fields
        private string _name;
        private int _id;
        private string _email;
        private static int _counter = 0;
        private Order _currentOrder;

        // construcotr

        public Customer(string name, string email) 
        {
            _counter++;
            _id = _counter;
            _name = name;
            _email = email;
            _currentOrder = new Order(this, "");
        }


        // properties


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int ID
        {
            get { return _id;}
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public Order currentOrder
        {
            get { return _currentOrder; }
        }

        //methods

        public override string ToString()
        {
            return $"Name: {_name}, Email: {_email}, Has an order: {(_currentOrder == null ? "No" : "Yes" )}";
        }
        
    }
}
