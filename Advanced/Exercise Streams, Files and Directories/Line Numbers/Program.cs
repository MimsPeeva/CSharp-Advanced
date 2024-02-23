//public class LineNumbers
//{
//    static void Main()
//    {

//        string inputFile = @"..\..\..\text.txt";
//        string outputFile = @"..\..\..\output.txt";
//        ProcessLines(inputFile, outputFile);
//    }
//    public static void ProcessLines(string inputFilePath, string outputFilePath)
//    {
//        string[] lines = File.ReadAllLines(inputFilePath);
//        for (int i = 0; i < lines.Length; i++)
//        {

//            int lettersN = lines[i].Where(char.IsLetter).Count();
//            int punctuationMarksN = lines[i].Where(char.IsPunctuation).Count();   
//            lines[i] = $"Line {i+1}: {lines[i]} ({lettersN}) ({punctuationMarksN})";
//        }
//        File.WriteAllLines(outputFilePath,lines);
//    }
//}
namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                StringBuilder text = new StringBuilder();

                string[] lines = File.ReadAllLines(inputFilePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    int lettersCount = lines[i].Count(char.IsLetter);
                    int symbolsCount = lines[i].Count(char.IsPunctuation);

                    text.AppendLine($"Line {i + 1}: {lines[i]} ({lettersCount})({symbolsCount})");
                }

                File.WriteAllText(outputFilePath, text.ToString());
            }
        }
    }
}