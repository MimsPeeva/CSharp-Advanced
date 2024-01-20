using System.Runtime.CompilerServices;

int rowsN = int.Parse(Console.ReadLine());
int[][]matrix = new int[rowsN][];
for (int row = 0; row < rowsN; row++)
{
    int[] cols = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
  
        matrix[row] = cols;
    
}
for (int row = 0; row < rowsN-1; row++)
{
    if (matrix[row].Length == matrix[row + 1].Length)
    {
        for (int i = 0; i < matrix[row].Length; i++)
        {
            matrix[row][i] *= 2;
            matrix[row + 1][i] *= 2;
        }
    }
    else
    {
        for (int i = 0; i < matrix[row].Length; i++)
        {
            matrix[row][i] /= 2;

        }
        for (int i = 0; i < matrix[row+1].Length; i++)
        {
            matrix[row + 1][i] /= 2;
        }
    }
}
    string input = string.Empty;
while ((input = Console.ReadLine())!="End")
{
    string[] tokens = input.Split();
    string command = tokens[0];
   
    if (command == "Add")
    {
        if (ValidCoordinates(matrix, tokens))
            {
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            int value = int.Parse(tokens[3]);
            matrix[row][col] += value;
        }
    }
    else if (command == "Subtract")
    {
        if (ValidCoordinates(matrix, tokens))
        {
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            int value = int.Parse(tokens[3]);
            matrix[row][col] -= value;
        }
    }
}
for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix[row].Length; col++)
    {
        Console.Write(matrix[row][col] + " ");
    }
    Console.WriteLine();
}

  static bool ValidCoordinates(int[][]matrix, string[]tokens)
{
    return int.Parse(tokens[1]) >= 0 && int.Parse(tokens[1]) <= matrix.GetLength(0)
        && int.Parse(tokens[2]) >= 0 && int.Parse(tokens[2]) < matrix[int.Parse(tokens[1])].Length;
}
/*
5
10 20 30
1 2 3
2
2
10 10
Add 0 10 10
Add 0 0 10
Subtract -3 0 10
Subtract 3 0 10
End
 */