using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public static class CustomerRepository
    {
        // instance fields
        private static Dictionary<int, Customer> _customers;


        //properties
        public static int Count { get { return _customers.Count; } }

        public static Dictionary<int, Customer> Customers
        {
            get { return _customers; }
        }




        //constructor
        static CustomerRepository()
        {
            _customers = new Dictionary<int, Customer>();
        }

        // methods
        public static bool AddCustomer(Customer aCustomer) 
        { 
            if (!_customers.ContainsKey(aCustomer.ID))
            {
                _customers.Add(aCustomer.ID, aCustomer);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DeleteCustomer(Customer aCustomer)
        {
            bool sucess = _customers.Remove(aCustomer.ID);
            return sucess;
        }
        public static bool UpdateByID(int ID, Customer aCustomer)
        {
            if (_customers.ContainsKey(ID))
            {
                _customers[ID].Email = aCustomer.Email;
                _customers[ID].Name = aCustomer.Name;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool UpdateByObject(Customer existingCustomer, Customer newCustomer)
        {
            if (_customers.ContainsValue(existingCustomer))
            {
                UpdateByID(existingCustomer.ID, newCustomer);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<Customer> SearchName(string name)
        {
            List<Customer> result = new List<Customer>();
            foreach (Customer aCustomer in _customers.Values)
            {
                if (aCustomer.Name == name)
                {
                    result.Add(aCustomer);
                }
            }
            return result;
        }
        public static void PrintCustomers()
        {
            Console.WriteLine("All Registered Customers:");
            foreach (Customer customer in _customers.Values)
            {
                Console.WriteLine($"{customer.ID}. {customer.Name}, Email: {customer.Email}");
            }
        }


    }
}
