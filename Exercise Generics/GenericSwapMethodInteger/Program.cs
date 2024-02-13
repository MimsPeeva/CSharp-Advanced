namespace GenericSwapMethodInteger;
public class StartUp
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        List<int> list = new List<int>();
        for (int i = 0; i < n; i++)
        {
           
            list.Add(int.Parse(Console.ReadLine()));
        }
        int[] swapCommand = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int firstIndex = swapCommand[0];
        int secondIndex = swapCommand[1];

        SwapElements(list, firstIndex, secondIndex);

        foreach (var item in list)
        {
            Console.WriteLine($"{item.GetType()}: {item}");
        }

    }
    public static void SwapElements<T>(List<T> list, int firstIndex, int secondIndex)
    {
       
        (list[firstIndex], list[secondIndex]) = (list[secondIndex], list[firstIndex]);
    }
}
/*
3
7
123
42
0 2
 */