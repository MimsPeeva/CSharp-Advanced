int n = int.Parse(Console.ReadLine());
HashSet<string> nameList = new HashSet<string>();
for (int i = 0; i < n; i++)
{
    string name = Console.ReadLine();
    nameList.Add(name);
}
Console.WriteLine(string.Join("\n", nameList));
