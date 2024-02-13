int matrixSize = int.Parse(Console.ReadLine());
char[,] matrix = ReadMatrix(matrixSize, matrixSize);
int currRow = 0;
int currCol = 0;
for (int row = 0; row < matrixSize; row++)
{
    for (int col = 0; col < matrixSize; col++)
    {
        if (matrix[row, col] == 'S')
        {
            currRow = row;
            currCol = col;
            break;
        }
    }
}
string command = string.Empty;
int amount = 0;
while ((command = Console.ReadLine()) != "collect the nets")
{
    matrix[currRow, currCol] = '-';
	if (command == "up")
	{
		currRow--;
        if (currRow < 0)
        {
            currRow = matrixSize - 1;
        }
    }
	else if (command == "down")
    {
        currRow++;
        if (currRow >= matrixSize)
        {
            currRow = 0;
        }
    }
    else if (command == "left")
    {
        currCol--;
        if (currCol < 0)
        {
            currCol = matrixSize - 1;
        }
    }
    else if (command == "right")
    {
        currCol++;
         if (currCol >= matrixSize)
        {
            currCol = 0;
        }
    }
if (matrix[currRow, currCol] != '-')
{
    if (matrix[currRow, currCol] == 'W')
    {
        Console.WriteLine("You fell into a whirlpool! The ship sank and you lost the fish you caught." + " " +
            $"Last coordinates of the ship: [{currRow},{currCol}]");
        return;
    }
    else
    {
        amount += int.Parse(matrix[currRow,currCol].ToString());
    }
}
matrix[currRow, currCol] = 'S';
}

if (amount < 20)
{
    Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20-amount} tons of fish more.");
}
else
{
    Console.WriteLine("Success! You managed to reach the quota!");  

}
if (amount > 0)
{ Console.WriteLine($"Amount of fish caught: {amount} tons."); }
    PrintMatrix(matrix, symbol => Console.Write(symbol));



char[,] ReadMatrix(int rows,int cols)
{
    char[,] matrix = new char[rows,cols];
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


void PrintMatrix<T>(T[,] matrix, Action<T>print)
{
	for (int row = 0; row < matrix.GetLength(0); row++)
	{
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            print(matrix[row,col]);
        }
        Console.WriteLine();
    }
}

/*
5
S---9
777-1
W333-
11111
-----
down
down
right
down
collect the nets
*/