int n = int.Parse(Console.ReadLine());
Stack<string> stringStack = new Stack<string>();
string text = string.Empty;
for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
       .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
    int command = int.Parse(input[0]);
    if (command == 1)
    {
         text += input[1];
        stringStack.Push(text);
    }
    else if (command == 2)
    {
        int count = int.Parse(input[1]);
        text = text.Substring(0, text.Length - count);
        stringStack.Push(text);
    }
    else if (command == 3)
    {
        int index = int.Parse(input[1]);
        Console.WriteLine(text[index-1]);
    }
    else if (command == 4)
    {
        stringStack.Pop();
        if (stringStack.Count > 0)
        {
            text = stringStack.Peek();
        }
        else
        {
            text = string.Empty;
        }
    }
}