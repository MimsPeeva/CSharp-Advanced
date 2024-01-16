using System.Security.Cryptography.X509Certificates;

string[] input = Console.ReadLine().Split(' ').Reverse().ToArray();
Stack<string>stack = new Stack<string>();
foreach (string item in input)
{
stack.Push(item);
}
int sum = int.Parse(stack.Pop());
while(stack.Count>0)
{
    string currentChar = stack.Pop();
    if (currentChar == "+")
    {
     sum += int.Parse(stack.Pop());
        continue;

    }
    else if (currentChar == "-")
    {
        sum -= int.Parse(stack.Pop());
        continue;

    }

}
Console.WriteLine(sum);
//2 + 5 + 10 - 2 - 1