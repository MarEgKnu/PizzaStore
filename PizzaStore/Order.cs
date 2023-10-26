using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Order
    {
        // instance fields
        private List<OrderLine> _itemsInOrder;
        private Customer _purchaser;
        private string _comment;
        private DateTime _created;
        private int _id;
        private static int _counter;
        private const double _salesTax = 1.25;
        private const double _deliveryCost = 40;

        //constructor

        public Order(Customer purchaser, string comment)
        {
            if (_itemsInOrder == null) // if its null, create list before it can be modified
            {
                _itemsInOrder = new List<OrderLine>();
            }
            _counter++;
            _created = DateTime.Now;
            _id = _counter;
            _purchaser = purchaser; 
            _comment = comment;
        }
        // properties

        public List<OrderLine> ItemsInOrder
        {
            get { return _itemsInOrder; }
        }
        public Customer Purchaser
        {
            get { return _purchaser; }
        }
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }

        }
        public DateTime Created
        {
            get { return _created; }

        }
        public int ID
        {
            get { return _id; }
        }
        // methods
        public bool AddItem(Pizza menuItem)
        {
            if (menuItem.OnMenu)
            {
                OrderLine item = new OrderLine(menuItem);
                _itemsInOrder.Add(item);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveItem(OrderLine pizza)
        {
            bool found = _itemsInOrder.Remove(pizza);
            return found;
        }
        public double CalculateOrderPrice()
        {
            double totalPrice = 0;
            foreach (OrderLine item in _itemsInOrder)
            {
                totalPrice += item.CalculateOrderLinePrice();
            }
            totalPrice = totalPrice * _salesTax;
            totalPrice = totalPrice + _deliveryCost;
            return totalPrice;
        }
        private static bool CheckToppings(Topping theTopping, List<Topping> defaultToppings) 
        { 
            foreach (Topping defaultTopping in defaultToppings)
            {
                if (defaultTopping.ID == theTopping.ID)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            string resString = "";
            resString = resString + $"Customer: {_purchaser.Name}, Comment: {_comment}, Created on: {_created}, Order ID: {_id}\n";
            foreach (OrderLine item in _itemsInOrder)
            {
                resString += item.ToString();
                resString += "\n";
            }
            resString = resString + $"Total cost: {CalculateOrderPrice()}";
            return resString;
        }
        //public static string PizzasListToString(List<OrderLine> obj)
        //{
        //    string toppingsString = "";
        //    for (int count = 1; count <= obj.Count; count++)
        //    {
        //        if (count == obj.Count)
        //        {
        //            toppingsString += obj[count - 1].Name;
        //        }
        //        else
        //        {
        //            toppingsString += obj[count - 1].Name + ", ";
        //        }
        //    }
        //    return toppingsString;
        //}
    }
}
