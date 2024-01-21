int usernamesCount = int.Parse(Console.ReadLine());
HashSet<string> usernames = new HashSet<string>();
for (int i = 0; i < usernamesCount; i++)
{
    string username = Console.ReadLine();
    usernames.Add(username);
}
Console.WriteLine(string.Join("\n", usernames));
/*
6
John
John
John
Peter
John
Boy1234
*/