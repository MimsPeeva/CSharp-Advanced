int matrixSize = int.Parse(Console.ReadLine());
char[,] matrix = ReadMatrix(matrixSize, matrixSize);
int currRow = 0;
int currCol = 0;

int enemyCount = 0;

int armorValue = 300;

for (int row = 0; row < matrixSize; row++)
{
    for (int col = 0; col < matrixSize; col++)
    {
        if (matrix[row, col] == 'J')
        {
            currRow = row;
            currCol = col;
            break;
        }
    }
}

char[,] ReadMatrix(int rows, int cols)
{
    char[,] matrix = new char[rows, cols];
    for (int row = 0; row < matrixSize; row++)
    {
        string line = Console.ReadLine();
        for (int col = 0; col < matrixSize; col++)
        {
            matrix[row, col] = line[col];
        }
    }
    return matrix;
}


void PrintMatrix<T>(T[,] matrix, Action<T> print)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            print(matrix[row, col]);
        }
        Console.WriteLine();
    }
}