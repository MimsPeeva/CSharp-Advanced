using System.Data;

int[] matrixSize = Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    .ToArray();
int rows = matrixSize[0];
int cols = matrixSize[1];

int[,] matrix = ReadMatrix(matrixSize[0], matrixSize[1], ", ");
int maxMatrixSum = matrix[0,0];
int maxSquareRow = 0;
int maxSquareCol = 0;
for (int row = 0;  row< rows-1; row++)
{
    for (int col = 0; col < cols-1; col++)
    {
        int squareSum = matrix[row, col] + matrix[row + 1, col] + 
            matrix[row, col + 1] + matrix[row+1,col+1];

        if (squareSum > maxMatrixSum)
        { maxMatrixSum = squareSum;
            maxSquareRow = row;
            maxSquareCol = col;
        }
    }
}
Console.WriteLine($"{matrix[maxSquareRow, maxSquareCol]} {matrix[maxSquareRow, maxSquareCol+1]}");
Console.WriteLine($"{matrix[maxSquareRow+1, maxSquareCol]} {matrix[maxSquareRow + 1, maxSquareCol + 1]}");
Console.WriteLine(maxMatrixSum);


int[,] ReadMatrix(int rows, int cols, string separator)
{
    int[,] matrix = new int[rows, cols];
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        int[] rowArray = Console.ReadLine()
        .Split(separator)
        .Select(int.Parse)
        .ToArray();
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[row, col] = rowArray[col];
        }
    }
    return matrix;
}