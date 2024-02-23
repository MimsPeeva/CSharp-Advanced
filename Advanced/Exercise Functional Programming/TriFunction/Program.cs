using System.Security.Cryptography.X509Certificates;

int number = int.Parse(Console.ReadLine());
string[] names = Console.ReadLine()
    .Split(' ',StringSplitOptions.RemoveEmptyEntries);
Func<string, int, bool> getSum = (name, number) => name.Sum(x=>x) >= number;
Func <string[], int, Func<string, int, bool>,string> getFirstName = (name, min, check) => names.First(x=>check(x,min));
Console.WriteLine(getFirstName(names,number,getSum));