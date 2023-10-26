using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaStore
{
    public static class UserDialog
    {
        // constructor
        static UserDialog()
        {

        }

        public static readonly Dictionary<string, string> MainMenu = new Dictionary<string, string>()
        {
            {"0", "Quit" },
            {"1", "Add new to pizza to the menu" },
            {"2", "Delete pizza" },
            {"3", "Update pizza" },
            {"4", "Search Pizza" },
            {"5", "Display pizza menu" },
            {"6", "Add new customer" },
            {"7", "Delete customer" },
            {"8", "Update customer" },
            {"9", "Display customers" }
        };
        //methods


        public static void Run()
        {
            while (true)
            {
                string choice = MenuChoice(MainMenu, "Choose one of the options above by typing in the key");
                switch (choice)
                {
                    case "0":
                        return;   
                    case "1": // add new pizza to the menu
                        Pizza? pizza = CreatePizzaDialog(); // skriv sekvensdiagram over disse linjer
                        if (pizza != null)
                        {
                            MenuCatalog.AddItem(pizza);
                        }
                        continue;
                    case "2": // delete pizza
                        Pizza? pizzaToDelete = PickPizzaDialog("Pick a pizza to delete by typing in the accociated key");
                        if (pizzaToDelete != null)
                        {
                            // it returns null if the user wants to quit
                            if (YesNoMenu("Delete", "Don't delete", $"Are you sure you want to delete the following pizza?\n{pizzaToDelete}") == true)
                            {
                                // if user types in y, delete the pizza
                                MenuCatalog.DeleteItem(pizzaToDelete);
                                continue;
                            }
                        }
                        continue;
                    case "3": // update pizza
                        Pizza? pizzaToUpdate = PickPizzaDialog("Pick a pizza to update by typing in the accociated key");
                        if (pizzaToUpdate != null)
                        {
                            // if its null, the user wants to quit
                            Pizza? newPizza = CreatePizzaDialog();
                            if (newPizza != null )
                            {
                                // if null here, the user wants to exit to main menu
                                MenuCatalog.UpdateByObject(pizzaToUpdate, newPizza);
                            }
                        }               
                        continue;
                    case "4": // search pizza
                   
                        Console.WriteLine("Type in the pizza ID to search for:");
                        string searchID = InputStringMenu("Type in the pizza ID to search for:\n" +
                                                          "or 0 to quit");
                        if (searchID !=  "0")
                        {
                            Pizza? result = MenuCatalog.GetPizzaByID(searchID);
                            if (result == null)
                            {
                                Console.WriteLine("No matching pizza found\n" +
                                                  "Press any key to continue.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Search result:\n" +
                                                 $"{result}\n" +
                                                 $"Press any key to continue.");
                                Console.ReadKey();
                            }
                            break;
                        }
                        else
                        {
                            break;
                        }   
                    case "5": // show pizza menu
                        Console.Clear();
                        MenuCatalog.PrintMenu();
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        break;
                    case "6": // add new customer
                        Customer? customer = CreateCustomerDialog(); // skriv sekvensdiagram over disse linjer
                        if (customer != null)
                        {
                            CustomerRepository.AddCustomer(customer);
                        }
                        continue;
                    case "7": // delete customer
                        Customer? customerToDelete = PickCustomerDialog("Pick a customer to delete by typing in the accociated key");
                        if (customerToDelete != null)
                        {
                            // it returns null if the user wants to quit
                            if (YesNoMenu("Delete", "Don't delete", $"Are you sure you want to delete the following customer?\n{customerToDelete}") == true)
                            {
                                // if user types in y, delete the pizza
                                CustomerRepository.DeleteCustomer(customerToDelete);
                                continue;
                            }
                        }
                        continue;
                    case "8": // update customer
                        Customer? customerToUpdate = PickCustomerDialog("Pick a customer to update by typing in the accociated key");
                        if (customerToUpdate != null)
                        {
                            // if its null, the user wants to quit
                            Customer? newCustomer = CreateCustomerDialog();
                            if (newCustomer != null)
                            {
                                // if null here, the user wants to exit to main menu
                                CustomerRepository.UpdateByObject(customerToUpdate, newCustomer);
                            }
                        }
                        continue;
                    case "9": // display customers
                        Console.Clear();
                        CustomerRepository.PrintCustomers();
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static string MenuChoice(Dictionary<string, string> choices, string msg)
        {
            // endless loop untill you type in a valid key and return to caller
            while (true)
            {
                Console.Clear();
                foreach (var item in choices)
                {
                    Console.WriteLine($"{item.Key}.  {item.Value}");
                }
                Console.WriteLine(msg);
                string? choice = Console.ReadLine();
                if (choice == null)
                {
                    Console.WriteLine("Invalid input. Press any key to continue");
                    Console.ReadKey();
                    continue;
                }
                foreach (var item in choices)
                {
                    if (item.Key == choice)
                    {
                        return choice;
                    }
                }
                Console.WriteLine("Invalid input. Press any key to continue");
                Console.ReadKey();
            }
            
        }
        private static Pizza? CreatePizzaDialog()
        {
            while (true)
            {
                string? MenuID;
                string? name;
                string? priceString;
                double price;
                bool? glutenFree;
                bool? family;
                bool? deepPan;
                bool? onMenu;
                MenuID = InputStringMenu("Enter MenuID\n" +
                                         "or 0 to quit");

                if (MenuCatalog.DoesMenuIdExist(MenuID))
                {
                    Console.WriteLine("Failure: MenuID already exists. Press any key to continue");
                    Console.ReadKey();
                    continue;
                }
                else if (MenuID == "0")
                {
                    return null;
                }
                name = InputStringMenu("Enter name:\n" +
                                       "or 0 to quit");
                if (name == "0")
                {
                    return null;
                }
                Console.WriteLine("Enter Price (uses dot(.) as seperator)");
                priceString = Console.ReadLine();
                if (priceString == null)
                {
                    Console.WriteLine("Failure: null input. Press any key to continue");
                    Console.ReadKey();
                    continue;
                }
                try
                {
                    price = double.Parse(priceString, CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {

                    Console.WriteLine("Failure: invalid input. Press any key to continue");
                    Console.ReadKey();
                    continue;
                }               
                glutenFree = YesNoMenu("Gluten free", "Not gluten free", "Choose if the pizza is gluten free by entering the key");
                if (glutenFree == null)
                {
                    // if the user presses 0 to quit, return null and jump back to main menu
                    return null;
                }
                bool newGlutenFree = glutenFree ?? false; // have to cast bool? into bool or compiler complains
                family = YesNoMenu("Family sized", "Not family sized", "Choose if the pizza should be family sized by entering the key");
                if (family == null)
                {
                    // if the user presses 0 to quit, return null and jump back to main menu
                    family = false;
                    return null;
                }
                bool newFamily = family ?? false;

                deepPan = YesNoMenu("Deep pan", "Not deep pan", "Choose if the pizza is deep pan by entering the key");
                if (deepPan == null)
                {
                    // if the user presses 0 to quit, return null and jump back to main menu
                    return null;
                }
                bool newDeepPan = deepPan ?? false;

                onMenu = YesNoMenu("On the menu", "Not on the menu", "Choose if the pizza should start being on the menu by entering the key");
                if (onMenu == null)
                {
                    // if the user presses 0 to quit, return null and jump back to main menu
                    return null;
                }
                bool newOnMenu = onMenu ?? false;

                List<Topping> toppingsList = ChooseToppings();
                return new Pizza(price, name, MenuID, newFamily, toppingsList, newDeepPan, newGlutenFree, newOnMenu);
            }
        }
        public static List<Topping> ChooseToppings()
        {
            List<Topping> toppingList = new List<Topping>();
            while (true)
            {
                Dictionary<string, string> toppingDict = new Dictionary<string, string>();
                toppingDict.Add("0", "Continue with selected toppings");
                foreach (var topping in ToppingRepository.Toppings)
                {
                    // topping has to be on the menu
                    if (topping.Value.OnMenu)
                    {
                        toppingDict.Add(topping.Key.ToString(), topping.Value.Name);
                    }
                }
                int choice = int.Parse(MenuChoice(toppingDict, $"Choose the toppings to be on the pizza by entering the key\nChoose a already selected item to de-select\nCurrently added: {Topping.ToppingsListToString(toppingList)}"));
                if (choice == 0)
                {
                    return toppingList;
                }
                else if (toppingList.Contains(ToppingRepository.Toppings[choice]) )
                {
                    // if it already is selected, de-select it
                    toppingList.Remove(ToppingRepository.Toppings[choice]);
                }
                else
                {
                    // if it isn't, select it
                    toppingList.Add(ToppingRepository.Toppings[choice]);
                }
            }
        }
        private static Pizza? PickPizzaDialog(string pickMsg)
        {
            while (true)
            {
                Dictionary<string, string> pizzaMenu = new Dictionary<string, string>();
                pizzaMenu.Add("0", "Go back");
                foreach (var item in MenuCatalog.Pizzas)
                {
                    pizzaMenu.Add(item.Key, item.Value.Name + ", Price: " + item.Value.Price);
                }
                string choice = MenuChoice(pizzaMenu, pickMsg);    
                if (choice == "0")
                {
                    return null;
                }
                return MenuCatalog.Pizzas[choice];
            }
        }
        private static bool? YesNoMenu(string yes, string no, string msg)
        {
            while (true)
            {
                string choice = MenuChoice(new Dictionary<string, string> { { "y", yes }, { "n", no }, { "0", "Quit" } }, msg);
                switch (choice)
                {
                    case "y":
                        return true;
                    case "n":
                        return false;
                    case "0":
                        return null;
                    default:
                        break;
                }
            }
        }
        private static string InputStringMenu(string msg)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(msg);
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Failure: null input. Press any key to continue");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    return input;
                }
            }

        }
        private static Customer? CreateCustomerDialog()
        {
            while (true)
            {
                string name = InputStringMenu("Enter customer name:\n" +                                              "or 0 to quit");
                if (name == "0")
                {
                    return null;
                }
                string email = InputStringMenu("Enter customer email:\n" +                                              "or 0 to quit");
                if (email == "0")
                {
                    return null;
                }
                return new Customer(name, email);

            }

        }
        private static Customer? PickCustomerDialog(string pickMsg)
        {
            while (true)
            {
                Dictionary<string, string> customerChoices = new Dictionary<string, string>();
                customerChoices.Add("0", "Go back");
                foreach (var item in CustomerRepository.Customers)
                {
                    customerChoices.Add(item.Key.ToString(), item.Value.Name + ", Email: " + item.Value.Email);
                }
                string choice = MenuChoice(customerChoices, pickMsg);
                if (choice == "0")
                {
                    return null;
                }
                return CustomerRepository.Customers[int.Parse(choice)];
            }
        }

    }
}
