namespace GroceriesManagement
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            GroceriesStore store = new(5);

            Product apples = new("Apples", 1.20);
            Product oranges = new("Oranges", 2.80);
            Product bananas = new("Bananas", 1.50);
            Product grapes = new("Grapes", 2.20);
            Product watermelon = new("Watermelon", 1.90);

            store.AddProduct(apples);
            store.AddProduct(oranges);
            store.AddProduct(bananas);
            store.AddProduct(grapes);
            store.AddProduct(watermelon);

            Product cherries = new("Cherries", 5.70);
            store.AddProduct(cherries);

            Console.WriteLine(store.RemoveProduct("Grapes")); //True

            Console.WriteLine(store.RemoveProduct("Pears")); //False

            store.AddProduct(cherries);

            Console.WriteLine(store.SellProduct("Apples", 1.5)); //Apples = 1.80$
            Console.WriteLine(store.SellProduct("Bananas", 2.4)); //Banans = 3.60$
            Console.WriteLine(store.SellProduct("Grapes", 2)); //Product not found
            Console.WriteLine(store.SellProduct("Apples", 2.5)); //Apples = 3.00$
            Console.WriteLine(store.SellProduct("Watermelon", 15)); //Watermelon = 28.50$
            Console.WriteLine(store.SellProduct("Cherries", 0.5)); //Cherries = 2.85$

            Console.WriteLine(store.GetMostExpensive()); //Cherries: 5.70$

            Console.WriteLine(store.CashReport());

            Console.WriteLine(store.PriceList());

        }
    }
}