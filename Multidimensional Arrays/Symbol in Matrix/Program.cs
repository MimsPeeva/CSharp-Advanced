int matrixSize = int.Parse(Console.ReadLine());
char[,] matrix = new char[matrixSize, matrixSize];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    string symbols = Console.ReadLine();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = symbols[col];

    }
}
char symbolToSearch = char.Parse(Console.ReadLine());
bool isFound = false;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        if (symbolToSearch == matrix[row, col])
        { Console.WriteLine($"({row}, {col})"); isFound = true; break; }
       
    }
if (isFound == true)
{ break; }
}
    if (isFound == false)
{
    Console.WriteLine($"{symbolToSearch} does not occur in the matrix");
}

    
  
/*
3
ABC
DEF
X!@
!
*/