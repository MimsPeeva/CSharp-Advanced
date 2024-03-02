using System.Runtime.CompilerServices;
using System.Text;

namespace ShoppingSpree;
public class StartUp
{
    static void Main()
    {
        char[] delims = new[] {';', '='};
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        string[]peopleData= Console.ReadLine()
            .Split(delims,StringSplitOptions.RemoveEmptyEntries);
        string[] productsData = Console.ReadLine()
           .Split(delims, StringSplitOptions.RemoveEmptyEntries);
        try 
        {
            for (int i = 0; i < peopleData.Length; i+=2)
            {
                people.Add(new Person(peopleData[i], int.Parse(peopleData[i+1])));
            }
            for (int i = 0; i < productsData.Length; i += 2)
            {
                products.Add(new Product(productsData[i], int.Parse(productsData[i + 1])));
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        string command = string.Empty;
        while ((command=Console.ReadLine())!="END")
        {
            string[] tokens = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Person person = people.Find(p => p.Name == tokens[0]);
            Product product = products.Find(p => p.Name == tokens[1]);
            try
            {
            if (person is not null
                && product is not null)
            {
                person.AddProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
            }

            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        foreach (var p in people)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{p.Name} - ");
            if (p.BagOfProducts.Count == 0)
            {
               sb.Append("Nothing bought");
                Console.WriteLine(sb.ToString());
                break;
            }
            else
            {
                sb.Append(string.Join(", ", p.BagOfProducts.Select(item=>item.Name))); ;
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
/*
Peter=11;George=4
Bread=10;Milk=2;
Peter Bread
George Milk
George Milk
Peter Milk
END

Maria=0
Coffee=2
Maria Coffee
END

John=-3
Peppers=1;Tomatoes=2;Cheese=3
John Peppers
John Tomatoes
John Cheese
END
 */