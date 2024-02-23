int matrixSize = int.Parse(Console.ReadLine());
char[,] matrix = ReadMatrix(matrixSize, matrixSize);
int currRow = -1;
int currCol =-1;

int enemyCount = 0;

uint armorValue = 300;
int hitTimes = 0;
for (int row = 0; row < matrixSize; row++)
{
    for (int col = 0; col < matrixSize; col++)
    {
        if (matrix[row, col] == 'J')
        {
            currRow = row;
            currCol = col;
        }
        if (matrix[row, col] == 'E')
        { enemyCount++; }
    }
}
string command = string.Empty;
while (armorValue > 0&&enemyCount>0)
{
    matrix[currRow, currCol] = '-';
    command = Console.ReadLine();
    //if (command == "left" && matrix[currRow, currCol - 1] == '-'
    //   || command == "right" && matrix[currRow, currCol + 1] == '-'
    //   || command == "up" && matrix[currRow - 1, currCol] == '-'
    //   || command == "down" && matrix[currRow + 1, currCol] == '-')
    //{
    //    continue;
    //}
    //else
    //{
        if (command == "up")
        {
            currRow--;
        }
      else  if (command == "down")
        {
            currRow++;
        }
       else if (command == "left")
        {
            currCol--;
        }
       else if (command == "right")
        {
            currCol++;
        }
        if (matrix[currRow, currCol] == 'E')
        {
            hitTimes++;
        enemyCount--;
            matrix[currRow, currCol] = '-';
            if (enemyCount == 0)
            {
                Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
            matrix[currRow, currCol] = 'J';

            break;
            }
            armorValue -= 100;
            if (armorValue == 0)
            {
                Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currRow}, {currCol}]!");
            matrix[currRow, currCol] = 'J';

            break;
            }
            continue;
        }
        if (matrix[currRow, currCol] == 'R')
        {
            armorValue = 300;
            matrix[currRow, currCol] = '-';
        }
   // }
}

//if (enemyCount==0)
//{ Console.WriteLine("Mission accomplished, you neutralized the aerial threat!"); }
//if (hitTimes == 3)
//{ Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currRow}, {currCol}]!"); }
PrintMatrix(matrix,symbol=>Console.Write(symbol));
   
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