int[] size = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToArray();

string[,] matrix = new string[size[0], size[1]];

int currRow = -1;
int currCol = -1;

int opponentsTouched = 0;
int moves = 0;

for (int i = 0; i < size[0]; i++)
{
    string[] row = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int j = 0; j < size[1]; j++)
    {
        matrix[i, j] = row[j].ToString();
        if (matrix[i, j] == "B")
        {
            currRow = i;
            currCol = j;
            matrix[i, j] = "-";
        }
    }
}

string command;
while ((command = Console.ReadLine()) != "Finish")
{
    if ((command == "left" && currCol == 0) ||
        (command == "right" && currCol == matrix.GetLength(1) - 1) ||
        (command == "up" && currRow == 0) ||
        (command == "down" && currRow == matrix.GetLength(0) - 1))
    {
        continue;
    }

    switch (command)
    {
        case "left":
            if (matrix[currRow, currCol - 1] == "O")
            {
                continue;
            }
            break;
        case "right":
            if (matrix[currRow, currCol + 1] == "O")
            {
                continue;
            }
            break;
        case "up":
            if (matrix[currRow - 1, currCol] == "O")
            {
                continue;
            }
            break;
        case "down":
            if (matrix[currRow + 1, currCol] == "O")
            {
                continue;
            }
            break;

    }

    moves++;
    switch (command)
    {
        case "left":
            currCol--;
            break;
        case "right":
            currCol++;
            break;
        case "up":
            currRow--;
            break;
        case "down":
            currRow++;
            break;

    }

    if (matrix[currRow, currCol] == "P")
    {
        opponentsTouched++;
        matrix[currRow, currCol] = "-";

        if (opponentsTouched == 3)
        {
            break;
        }
    }
}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {opponentsTouched} Moves made: {moves}");