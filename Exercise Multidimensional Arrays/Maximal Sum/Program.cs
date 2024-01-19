int[] matrixSize = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int rows = matrixSize[0];
int cols = matrixSize[1];
int[,] matrix = new int[rows, cols];
for (int row = 0; row < rows; row++)
{
    int [] input = Console.ReadLine()
     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = input[col];
    }
}
int maxMatrixSum = 0;
int maxRow = 0;
int maxCol = 0;
for (int row = 0; row < rows-2; row++)
{
    for (int col = 0; col < cols-2; col++)
    {
        int sum = matrix[row, col]  + matrix[row, col + 1] + matrix[row, col + 2]
            + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
            + matrix[row + 2, col] + +matrix[row + 2, col + 1] + matrix[row+2,col+2];
        if (sum > maxMatrixSum)
        {
            maxMatrixSum = sum;
            maxCol = col;
            maxRow = row;
        }
    }
}
Console.WriteLine($"Sum = {maxMatrixSum}");
Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]} {matrix[maxRow, maxCol + 2]}");
Console.WriteLine($"{matrix[maxRow+1, maxCol]} {matrix[maxRow+1, maxCol + 1]} {matrix[maxRow+1, maxCol + 2]}");
Console.WriteLine($"{matrix[maxRow+2, maxCol]} {matrix[maxRow+2, maxCol + 1]} {matrix[maxRow+2, maxCol + 2]}");
/*
4 5
1 5 5 2 4
2 1 4 -14 3
3 7 11 2 8
4 8 12 16 4
*/