// See https://aka.ms/new-console-template for more information

using PizzaStore;

//Create topping objects to be used and employee(currently useless)

Employee employee1 = new Employee("Jens Hansen");

Topping cheeseSauce = new Topping(10, "Cheese", true);

Topping tomatoSauce = new Topping(10, "Tomato Sauce", true);

Topping salami = new Topping(13, "Salami", true);

Topping ham = new Topping(15, "Ham", true);

Topping kebab = new Topping(13, "Kebab", true);

Topping salad = new Topping(10, "Salad", true);

ToppingRepository.AddTopping(cheeseSauce);
ToppingRepository.AddTopping(tomatoSauce);
ToppingRepository.AddTopping(salami);
ToppingRepository.AddTopping(ham);
ToppingRepository.AddTopping(kebab);
ToppingRepository.AddTopping(salad);
// list of the toppings

List<Topping> pepperoniToppings = new List<Topping>() { cheeseSauce, tomatoSauce, salami };

List<Topping> saladToppings = new List<Topping>() { cheeseSauce, tomatoSauce, salad };

List<Topping> margheritaToppings = new List<Topping>() { cheeseSauce, tomatoSauce};


// new customer

Customer customer1 = new Customer("Emil Jacobsen", "emiljacobsen@hotmail.com");

Customer customer2 = new Customer("Sussane Jørgensen", "susannej@hotmail.com");

Customer customer3 = new Customer("Magnus Jensen", "magjen@hotmail.com");

// new pizza template objects

Pizza pepperoniPizza = new Pizza(60, "Pepperoni Pizza", "1", false,pepperoniToppings, false, false, true);

Pizza saladPizza = new Pizza(65, "Salad Pizza", "2", false, saladToppings, false, false, true);

Pizza margheritaPizza = new Pizza(50, "Margherita Pizza", "3", false, margheritaToppings, false, false, true);

MenuCatalog.AddItem(pepperoniPizza);
MenuCatalog.AddItem(saladPizza);
MenuCatalog.AddItem(margheritaPizza);


CustomerRepository.AddCustomer(customer1);
CustomerRepository.AddCustomer(customer2);
CustomerRepository.AddCustomer(customer3);

MenuCatalog.PrintMenu();

UserDialog.Run();

Console.WriteLine(MenuCatalog.GetPizzaByID("4"));

// customer 1 adds a pepperonipizza with extra salad to order
customer1.currentOrder.AddItem(pepperoniPizza);

customer1.currentOrder.ItemsInOrder[0].AddTopping(salad);

// adds comment
customer1.currentOrder.Comment = "ingen pesto";

// customer 2 adds a saladpizza to order

customer2.currentOrder.AddItem(margheritaPizza);

customer2.currentOrder.AddItem(saladPizza);

customer2.currentOrder.ItemsInOrder[0].AddTopping(kebab);

// customer 3 adds margeritapizza to order

customer3.currentOrder.AddItem(saladPizza);

customer3.currentOrder.ItemsInOrder[0].AddTopping(salami);



// writes customer 2's order ToString

//Console.WriteLine(customer2.currentOrder);

// write all 3 customer's name, pizzas in order, and total price

//Console.WriteLine($"Customer 1: Pizza: {Order.PizzasListToString(customer1.currentOrder.ItemsInOrder)}, Customer Name: {customer1.Name}, Total Order Price: {customer1.currentOrder.CalculateOrderPrice()}");

//Console.WriteLine($"Customer 2: Pizza: {Order.PizzasListToString(customer2.currentOrder.ItemsInOrder)}, Customer Name: {customer2.Name}, Total Order Price: {customer2.currentOrder.CalculateOrderPrice()}");

//Console.WriteLine($"Customer 3: Pizza: {Order.PizzasListToString(customer3.currentOrder.ItemsInOrder)}, Customer Name: {customer3.Name}, Total Order Price: {customer3.currentOrder.CalculateOrderPrice()}");