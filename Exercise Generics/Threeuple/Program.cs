namespace Threeuple;
public class StarUp 
{
    public static void Main()
    {
        string[] firstLine = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string name = firstLine[0] + " " + firstLine[1];
        string adress = firstLine[2];
        string town = firstLine[3];
        Threeuple<string, string, string> firstL = new Threeuple<string, string, string>(name, adress, town);
        string[] secondLine = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string personName = secondLine[0];
        int amountOfBeerInL = int.Parse(secondLine[1]);
        string drunkOrNot = secondLine[2];
        IsDrunk(drunkOrNot);
        Threeuple<string, int, bool> secondL = new Threeuple<string, int, bool>(personName, amountOfBeerInL,IsDrunk(drunkOrNot));
        string[] thirdLine = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string name1 = thirdLine[0];
        double accountBalance = double.Parse(thirdLine[1]);
        string bankName = thirdLine[2];
        Threeuple<string, double, string> thirdL = new Threeuple<string, double, string>(name1, accountBalance, bankName);
        Console.WriteLine(firstL);
        Console.WriteLine(secondL);
        Console.WriteLine(thirdL);
    }

    private static bool IsDrunk(string drunkOrNot)
    {
        if (drunkOrNot == "drunk")
        { return true; }
        else return false;
    }
}
/*
Anatoly Andreevich Kutuzova Kaliningrad
Marley 9 not
Grant 2 NGB
*/