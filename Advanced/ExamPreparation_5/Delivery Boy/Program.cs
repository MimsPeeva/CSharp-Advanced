int[] fieldSize = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

char[,] matrix = new char[fieldSize[0],fieldSize[1]];
int currRow = 0;
int currCol = 0;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    string line = Console.ReadLine();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = line[col];
        if (matrix[row, col] == 'B')
        {
            currRow = row;
            currCol = col;
            break;
        }
    }
}

string command = string.Empty;

while(true)
{
    command = Console.ReadLine();
    if (matrix[currRow, currCol] == '-')
    {
        matrix[currRow, currCol] = '.';
    }
    if (matrix[currRow, currCol] == 'P')
    {
        matrix[currRow, currCol] = 'R';
        Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
    }
}