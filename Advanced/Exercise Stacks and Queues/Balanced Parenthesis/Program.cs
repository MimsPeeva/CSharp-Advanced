char[] input = Console.ReadLine().
    ToCharArray();
if (input.Length % 2 != 0)
{ Console.WriteLine("NO"); return; }
Stack<char> symbolsStack = new Stack<char>();
foreach (var c in symbolsStack)
{
    if ("{[(".Contains(c))
    { symbolsStack.Push(c); }
    else if (c == ')' && symbolsStack.Peek() == '(')
    {
        symbolsStack.Pop();
    }
    else if (c == '}' && symbolsStack.Peek() == '{')
    {
        symbolsStack.Pop();
    }
    else if (c == ']' && symbolsStack.Peek() == '[')
    {
        symbolsStack.Pop();
    }
}

{ Console.WriteLine(symbolsStack.Any()?"NO" : "YES"); }