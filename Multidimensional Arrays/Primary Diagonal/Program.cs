int matrixSize = int.Parse(Console.ReadLine());
int[,] matrix = ReadMatrix(matrixSize, matrixSize, " ");
int sum = 0;
for (int i = 0; i < matrixSize; i++)
{
    sum += matrix[i,i];
}
Console.WriteLine(sum);


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
/*
3
11 2 4
4 5 6
10 8 -12
*/