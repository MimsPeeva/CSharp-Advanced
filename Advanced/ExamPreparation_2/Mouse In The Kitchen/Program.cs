using System.Runtime.CompilerServices;

int[] size = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int cheeseNumber = 0;
int rowsCount = size[0];
int colsCount = size[1];
char[,] matrix = new char[rowsCount,colsCount];

int currRow =-1;
int currCol = -1;
for (int row = 0; row < rowsCount; row++)
{
    string line = Console.ReadLine();
    for (int col = 0; col < colsCount; col++)
    {
        matrix[row, col] = line[col];
    }
}

for (int row = 0; row < rowsCount; row++)
{
    for (int col = 0; col < colsCount; col++)
    {
        if (matrix[row, col] == 'M')
        {
            currRow = row;
            currCol = col;
            matrix[currRow, currCol] = '*';
        }
        if (matrix[row, col] == 'C')
        { cheeseNumber++; }
    }
}

string command = string.Empty;

while ((command = Console.ReadLine()) != "danger")
{
    matrix[currRow, currCol] = '*';
    if (IsOutside(command, currCol, currRow, colsCount, rowsCount))
    { break; }
    else
    {
        if (command == "left" && matrix[currRow, currCol - 1] == '@'
        || command == "right" && matrix[currRow, currCol + 1] == '@'
        || command == "up" && matrix[currRow - 1, currCol] == '@'
        || command == "down" && matrix[currRow + 1, currCol] == '@')
        {
            continue;
        }
        else
        {
            if (command == "up")
            {
                currRow--;

                //break;
            }
            else if (command == "down")
            {
                currRow++;

                //  break;
            }
            else if (command == "left")
            {
                currCol--;

                //break;
            }
            else if (command == "right")
            {
                currCol++;


                //break;
            }
            if (matrix[currRow, currCol] == 'C')
            {
                cheeseNumber--;
                matrix[currRow, currCol] = '*';
                if (cheeseNumber == 0)
                {
                    matrix[currRow, currCol] = 'M';
                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                    break;
                }
                continue;
            }
            if (matrix[currRow, currCol] == 'T')
            {
                Console.WriteLine("Mouse is trapped!");
                break;
            }
        }
    }
}
if (command == "danger")
{ Console.WriteLine("Mouse will come back later!"); }
matrix[currRow, currCol] = 'M';
PrintMatrix(matrix, symbol => Console.Write(symbol));




static bool IsOutside(string command, int currCol, int currRow, int colsCount, int rowsCount)
{
    if (command == "left" && currCol == 0
        || command == "right" && currCol == colsCount - 1
        || command == "up" && currRow == 0
        || command == "down" && currRow == rowsCount - 1)
    {
        Console.WriteLine("No more cheese for tonight!");
        return true;
    }
    else return false;
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
