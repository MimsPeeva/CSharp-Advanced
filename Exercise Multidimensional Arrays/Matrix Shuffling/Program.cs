using System.Data;

int[] matrixSize = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int rows = matrixSize[0];
int cols = matrixSize[1];
string[,] matrix = new string[matrixSize[0], matrixSize[1]];
for (int row = 0; row < matrixSize[0]; row++)
{
    string[] newRow = Console.ReadLine()
.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    for (int col = 0; col < matrixSize[1]; col++)
    {
        matrix[row, col] = newRow[col];
    }
}
string input = string.Empty;
while ((input = Console.ReadLine()) != "END")
{
    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (tokens[0] == "swap" && tokens.Length == 5)
    {
        int row1 = int.Parse(tokens[1]);
        int col1 = int.Parse(tokens[2]);
        int row2 = int.Parse(tokens[3]);
        int col2 = int.Parse(tokens[4]);

        if (IsValidSwap(matrix, row1, col1, row2, col2))
        {
            string temp = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = temp;


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    else
    { 
            Console.WriteLine("Invalid input!"); 
    }
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
}

bool IsValidSwap(string[,] matrix, int row1, int col1, int row2, int col2)
{
    return row1>=0 && row1<matrix.GetLength(0) 
        && col1>=0 && col1<matrix.GetLength(1)
        && row2 >= 0 && row2 < matrix.GetLength(0)
        && col2 >= 0 && col2 < matrix.GetLength(1);
}


/*
2 3
1 2 3
4 5 6
swap 0 0 1 1
swap 10 9 8 7
swap 0 1 1 0
END
 */