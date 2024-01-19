int[] matrixSize = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int rows = matrixSize[0];
int cols = matrixSize[1];
string[,]matrix = new string[rows, cols];
string[] snake = Console.ReadLine().Split("",StringSplitOptions.RemoveEmptyEntries);
for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
    matrix[row,col] = snake[col];
    }
}
foreach (var item in matrix)
{
    Console.WriteLine(item);
}
/*
5 6 
SoftUni
 */