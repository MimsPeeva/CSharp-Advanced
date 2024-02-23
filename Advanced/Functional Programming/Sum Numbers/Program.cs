int[] integers = Console.ReadLine()
    .Split(", ")
.Select(int.Parse)
.ToArray();
Console.WriteLine(integers.Count());
Console.WriteLine(integers.Sum());