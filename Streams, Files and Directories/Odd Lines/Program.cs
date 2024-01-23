namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";
            ExtractOddLines(inputFilePath, outputFilePath);
        }
        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                        int lineN = 0;
                    while (!reader.EndOfStream)
                    {
                        lineN++;
                        string line = reader.ReadLine();
                        if (lineN % 2 == 1)
                        {
                            continue;
                        }
                        Console.WriteLine(line);
                    }

                }
            }
        }
    }
}
