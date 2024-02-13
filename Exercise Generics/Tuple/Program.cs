using System.Text;
namespace Tuple;
public class StartUp
{
    public static void Main()
    {
        
string[] firstLine = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
string name = firstLine[0] + " " + firstLine[1];
string adress = firstLine[2];
       Tuple<string, string> personInfo = new Tuple<string, string>(name, adress);
string[] secondLine = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
string personName = secondLine[0];
int amountOfBeerInL = int.Parse(secondLine[1]);
        Tuple<string, int> person = new Tuple<string, int>(personName, amountOfBeerInL);
string[] thirdLine = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
int integerN = int.Parse(thirdLine[0]);
double doubleN = double.Parse(thirdLine[1]);

    Tuple<int, double> number = new Tuple<int, double>(integerN, doubleN);
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(personInfo.ToString());
        sb.AppendLine(person.ToString());
        sb.AppendLine(number.ToString());
        Console.WriteLine(sb.ToString().TrimEnd());
    }
}
/*
Adam Smith California
Mark 2
23 21.23212321
*/