int boardSize = int.Parse(Console.ReadLine());
char[,] matrix = ReadMatrix(boardSize, boardSize);
int moneyCount = 100;

int currRow = -1;
int currCol =-1;

bool isLost = false;
for (int row = 0; row < boardSize; row++)
{
    for (int col = 0; col < boardSize; col++)
    {
        if (matrix[row, col] == 'G')
        {
            currRow = row;
            currCol = col;
            matrix[currRow, currCol] = '-';
            continue;
        }
    }
}

string command = string.Empty;
while ((command=Console.ReadLine())!="end")
{

    if (command == "left" && currCol == 0
         || command == "right" && currCol == boardSize - 1
         || command == "up" && currRow == 0
         || command == "down" && currRow == boardSize - 1)
    { 
        isLost = true;
        break;
    }

            if (command == "left")
            { currCol--; }
            else if (command == "right")
            { currCol++; }
            else if (command == "up")
            { currRow--; }
            else if (command == "down")
            { currRow++; }

    
        if (matrix[currRow, currCol] == 'P')
        {
            moneyCount -= 200;
                
        }
         if (matrix[currRow, currCol] == 'W')
        {
            moneyCount += 100;
        }
        if (matrix[currRow, currCol] == 'J')
        {
            moneyCount += 100000;
                Console.WriteLine("You win the Jackpot!");
            break;
        }
            if (moneyCount < 0)
            {
                isLost = true;
                break;
            }
            matrix[currRow, currCol] = '-';
        }

if (isLost)
{
    Console.WriteLine("Game over! You lost everything!");

}
else
{
    matrix[currRow, currCol] = 'G';
    Console.WriteLine($"End of the game. Total amount: {moneyCount}$");
PrintMatrix(matrix, symbol => Console.Write(symbol));
}


char[,] ReadMatrix(int rows, int cols)
{
    char[,] matrix = new char[rows, cols];
    for (int row = 0; row < boardSize; row++)
    {
        string line = Console.ReadLine();
        for (int col = 0; col < boardSize; col++)
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
