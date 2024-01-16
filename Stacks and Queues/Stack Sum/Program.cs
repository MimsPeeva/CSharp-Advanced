using System.Collections;
/*
1 2 3 4
adD 5 6
REmove 3
eNd
 */
List<int> integers = Console.ReadLine().Split().Select(int.Parse).ToList();
Stack<int> stack = new Stack<int>(integers);
string inputs = Console.ReadLine().ToLower();
while (inputs != "end")
{
    string[] tokens = inputs.Split(' ');

    if (tokens[0]=="add")
    {
        int first = int.Parse(tokens[1]);
        int second = int.Parse(tokens[2]);
        stack.Push(first);
        stack.Push(second);
    }
    else
    {
        int first = int.Parse(tokens[1]);
        if (stack.Count >= first)
        {
            for (int i = 0; i < first; i++)
            {
                stack.Pop();
            }
        }
    }
    inputs = Console.ReadLine().ToLower();
}
Console.WriteLine($"Sum: {stack.Sum()}");