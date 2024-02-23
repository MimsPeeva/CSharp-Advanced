namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string us = Console.ReadLine();
            int level = int.Parse(Console.ReadLine());
            Hero hero = new Hero(us,level);

            Console.WriteLine(hero);
        }
    }
}