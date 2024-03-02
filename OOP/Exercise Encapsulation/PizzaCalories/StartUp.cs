namespace PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {
            try 
            {
                var pizzaData = Console.ReadLine()
                    .Split(" ");
                Pizza pizza = new Pizza(pizzaData[1]);

                var doughData = Console.ReadLine()
                   .Split(" ");
                Dough dough = new Dough(doughData[1], doughData[2],double.Parse(doughData[3]));
                pizza.Dough = dough;

                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Topping topping = new Topping(tokens[1], double.Parse(tokens[2]));
                    pizza?.AddToppings(topping);
                   // Console.WriteLine($"{pizza.Name}");
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
/*
Pizza Meatless
Dough Wholegrain Crispy 100
Topping Veggies 50
Topping Cheese 50
END

Pizza Burgas
Dough White Homemade 200
Topping Meat 123
END

Pizza Bulgarian
Dough White Chewy 100
Topping Sauce 20
Topping Cheese 50
Topping Cheese 40
Topping Meat 10
Topping Sauce 10
Topping Cheese 30
Topping Cheese 40
Topping Meat 20
Topping Sauce 30
Topping Cheese 25
Topping Cheese 40
Topping Meat 40
END

Pizza Bulgarian
Dough White Chewy 100
Topping Sirene 50
Topping Cheese 50
Topping Krenvirsh 20
Topping Meat 10
END
*/