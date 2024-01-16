int[] matrixSize = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int rows = matrixSize[0];
int cols = matrixSize[1];
char[,] matrix = new char[rows, cols];
for (int row = 0; row < rows; row++)
{
    char[] input = Console.ReadLine()
     .Split()
    .Select(char.Parse)
    .ToArray();
    for (int col = 0; col < cols; col++)
    {
        matrix[row,col] = input[col];
    }
}
int counter = 0;
for (int row = 0; row < rows-1; row++)
{
    if (row > 0)
    {
        for (int col = 0; col < cols - 1; col++)
        {
            char symbol1 = matrix[row, col];
            char symbol2 = matrix[row + 1, col];
            char symbol3 = matrix[row, col + 1];
            char symbol4 = matrix[row + 1, col + 1];

            if (symbol1 == symbol2 && symbol1 == symbol3 && symbol1 == symbol4)
            { counter++; }
        }
    }
}
Console.WriteLine(counter);
/*
3 4
A B B D
E B B B
I J B B
 */