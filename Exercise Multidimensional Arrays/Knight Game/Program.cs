
int n = int.Parse(Console.ReadLine());
char[][] jagged = new char[n][];
for (int i = 0; i < n; i++)
{
    jagged[i] = Console.ReadLine().ToCharArray();
}

int[,] possibleMooves = new int[n, n];

int removed = 0;
while (true)
{
    int maxCountMoves = int.MinValue;
    int rows = 0;
    int cols = 0;
    for (int row = 0; row < n; row++)
    {
        for (int col = 0; col < n; col++)
        {
            if (jagged[row][col] == 'K')
            {
                if (row - 1 > -1 && row - 1 < jagged.Length && col - 2 > -1 && col - 2 < jagged[row - 1].Length)
                {
                    if (jagged[row - 1][col - 2] == 'K')
                    {
                        possibleMooves[row, col]++;
                    }
                }
                if (row - 1 > -1 && row - 1 < jagged.Length && col + 2 > -1 && col + 2 < jagged[row - 1].Length)
                {
                    if (jagged[row - 1][col + 2] == 'K')
                    {
                        possibleMooves[row, col]++;
                    }
                }

                if (row + 1 > -1 && row + 1 < jagged.Length && col - 2 > -1 && col - 2 < jagged[row + 1].Length)
                {
                    if (jagged[row + 1][col - 2] == 'K')
                    {
                        possibleMooves[row, col]++;
                    }
                }
                if (row + 1 > -1 && row + 1 < jagged.Length && col + 2 > -1 && col + 2 < jagged[row + 1].Length)
                {
                    if (jagged[row + 1][col + 2] == 'K')
                    {
                        possibleMooves[row, col]++;
                    }
                }
                if (row - 2 > -1 && row - 2 < jagged.Length && col - 1 > -1 && col - 1 < jagged[row - 2].Length)
                {
                    if (jagged[row - 2][col - 1] == 'K')
                    {
                        possibleMooves[row, col]++;
                    }
                }
                if (row - 2 > -1 && row - 2 < jagged.Length && col + 1 > -1 && col + 1 < jagged[row - 2].Length)
                {
                    if (jagged[row - 2][col + 1] == 'K')
                    {
                        possibleMooves[row, col]++;
                    }
                }
                if (row + 2 > -1 && row + 2 < jagged.Length && col - 1 > -1 && col - 1 < jagged[row + 2].Length)
                {
                    if (jagged[row + 2][col - 1] == 'K')
                    {
                        possibleMooves[row, col]++;

                    }
                }
                if (row + 2 > -1 && row + 2 < jagged.Length && col + 1 > -1 && col + 1 < jagged[row + 2].Length)
                {
                    if (jagged[row + 2][col + 1] == 'K')
                    {
                        possibleMooves[row, col]++;
                    }
                }

            }
        }
    }
    for (int row = 0; row < n; row++)
    {
        for (int col = 0; col < n; col++)
        {
            if (possibleMooves[row, col] > maxCountMoves)
            {
                maxCountMoves = possibleMooves[row, col];
                rows = row;
                cols = col;
            }
        }
    }
    if (maxCountMoves > 0)
    {
        jagged[rows][cols] = '0';
        removed++;
        possibleMooves = new int[n, n];
    }
    else
    {
        break;
    }
}
Console.WriteLine(removed);