int[] matrixSize = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int rows = matrixSize[0];
int cols = matrixSize[1];
string[,]matrix = new string[rows, cols];
string snake = Console.ReadLine();
int snakeCounter = 0;
for (int row = 0; row < rows; row++)
{
    if (row % 2 == 0)
    {
        for (int col = 0; col < cols; col++)
        {
            matrix[row, col] = snake[snakeCounter].ToString();
            snakeCounter = GetSnakeValue(snake, snakeCounter);
        }
    }
    else 
    {
        for (int col = cols - 1; col >= 0; col--)
        {
       matrix[row, col] = snake[snakeCounter].ToString();
        snakeCounter = GetSnakeValue(snake, snakeCounter);
    }
}
}
for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        Console.Write($"{matrix[row, col]}");
    }
    Console.WriteLine();
}

static int GetSnakeValue(string snake, int counter)
{
    counter++;
    if (counter >= snake.Length)
    { counter = 0; }
    return counter;
}
/*
5 6 
SoftUni
 */