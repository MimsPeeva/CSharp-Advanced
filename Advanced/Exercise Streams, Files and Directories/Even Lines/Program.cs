namespace EvenLines
{
    using System;
    using System.Net.Http.Headers;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            char[] chArr = {'-', ',', '.', '!', '?'};
            int lineCounter = 0;
            using StreamReader reader = new StreamReader(inputFilePath);
            StringBuilder  str = new StringBuilder();
            string line;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (lineCounter % 2 == 0)
                {
                    foreach (char ch in line)
                    {
                        if (chArr.Contains(ch))
                        {
                            line = line.Replace(ch, '@');
                        }
                    }
                            string[] temp = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
                            str.Append(string.Join(" ", temp));
                }
                lineCounter++;
            }  
            return str.ToString();
        }
    }
}
