int[] matrixSize = Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    .ToArray();
int rows = matrixSize[0];
int cols = matrixSize[1];
int[,] matrix = ReadMatrix(rows, cols, " ");
int sum = 0;

for (int col = 0; col < cols; col++)
{
    for (int row = 0; row < rows; row++)

    {
        sum += matrix[row, col];
    }
Console.WriteLine(sum);
    sum = 0;
}


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