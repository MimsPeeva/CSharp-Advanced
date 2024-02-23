long n = long.Parse(Console.ReadLine());
long[][] pascal = new long[n][];
pascal[0] = new long[1] {1};
for (long row = 1; row < n; row++)
{
    pascal[row] = new long[row+1];
	for (long col = 0; col < pascal[row].Length; col++)
	{
        if (col < pascal[row-1].Length)
        {
            pascal[row][col] += pascal[row - 1][col];
        }
        if (col > 0)
        {
            pascal[row][col] += pascal[row - 1][col - 1];
        }
    }
}
for (long row = 0; row < pascal.Length; row++)
{
    for (long col = 0; col < pascal[row].Length; col++)
    {
        Console.Write(pascal[row][col] + " ");
    }
    Console.WriteLine();
}