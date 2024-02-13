using stack;

CustomStack<int> stack = new();

string[] delims = {", ", " "};

string lines = string.Empty;
while ((lines = Console.ReadLine()) != "END")
{
    string[] tokens = lines.Split(delims, StringSplitOptions.RemoveEmptyEntries);
    string command = tokens[0];
    if (command == "Push")
    {
        for (int i = 1; i < tokens.Length; i++)
        {
            stack.Push(int.Parse(tokens[i]));
        }
    }
    else if (command == "Pop")
    {
        try
        {
            stack.Pop();
        }
        catch(InvalidOperationException)
        {
            Console.WriteLine("No elements");
        }
    }
}
foreach (var el in stack)
{
    Console.WriteLine(el);
}
foreach (var el in stack)
{
    Console.WriteLine(el);
}
/*
Push 1, 2, 3, 4
Pop
Pop
END
 */