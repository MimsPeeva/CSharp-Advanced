int matrixRows = int.Parse(Console.ReadLine());
int[][] matrix = new int[matrixRows][];
for (int row = 0; row < matrix.Length; row++)
{
    matrix[row] = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();
    for (int col = 0; col < matrix[row].Length; col++)
    {
    }
}
string input = string.Empty;
while ((input=Console.ReadLine())!="END")
{
    string[] tokens = input.Split();
    string command = tokens[0];
    int row = int.Parse(tokens[1]);
    int col = int.Parse(tokens[2]);
    int value = int.Parse(tokens[3]);
    if (row <0||row>= matrix.Length || matrix[row].Length<=col || col<0)
    { Console.WriteLine("Invalid coordinates"); }
 else  if (command == "Add")
    {
        matrix[row][col] += value;
    }
    else if (command == "Subtract")
    {
        matrix[row][col] -= value;
    }
}
foreach (int[] row in matrix)
    Console.WriteLine(string.Join(" ", row));
/*
4
1 2 3 4
5
8 7 6 5
4 3 2 1
Add 4 4 100
Add 3 3 100
Subtract -1 -1 42
Subtract 0 0 42
END
 */