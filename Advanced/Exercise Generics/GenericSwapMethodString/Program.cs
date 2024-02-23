namespace GenericSwapMethodString;
public class StartUp
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        List<string> list = new List<string>();
        for (int i = 0; i < n; i++)
        {
            //string input = Console.ReadLine();
            //list.Add(input);
            list.Add(Console.ReadLine());
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
        //Option 1
        //  T temp = list[firstIndex];
        //  list[firstIndex] = list[secondIndex];
        //  list[secondIndex] = temp;

        //Option 2
        (list[firstIndex], list[secondIndex]) = (list[secondIndex], list[firstIndex]);
    }
}
/*
3
Peter
George
Swap me with Peter
0 2
 */