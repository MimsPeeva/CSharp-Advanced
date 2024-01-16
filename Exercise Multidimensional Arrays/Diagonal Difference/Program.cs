int matrixSize = int.Parse(Console.ReadLine());
int[,] matrix = new int[matrixSize, matrixSize]; 
int sumPrimaryDiagonal = 0;
int sumSecondaryDiagonal = 0;
for (int row = 0; row < matrixSize; row++)
{
	int[] input = Console.ReadLine()
		.Split(' ')
		.Select(int.Parse)
		.ToArray();
	for (int col = 0; col < matrixSize; col++)
	{

	matrix[row,col] = input[col];
	}
}
for (int i = 0; i < matrixSize; i++)
{
	sumPrimaryDiagonal += matrix[i, i];
	sumSecondaryDiagonal += matrix[i, matrixSize - 1 - i];
}
Console.WriteLine(Math.Abs(sumPrimaryDiagonal-sumSecondaryDiagonal));