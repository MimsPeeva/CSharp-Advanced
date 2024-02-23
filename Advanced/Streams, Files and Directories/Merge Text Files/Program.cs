namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader firstReader = new StreamReader(firstInputFilePath))

            using (StreamReader secondReader = new StreamReader(secondInputFilePath))

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string lineFirstFile = firstReader.ReadLine();
                string lineSecondFile = secondReader.ReadLine();
                {
                    while (lineFirstFile != null || lineSecondFile != null)
                    {
                        if (lineFirstFile != null)
                        {
                            writer.WriteLine(lineFirstFile);
                        }
                        if (lineSecondFile != null)
                        {
                            writer.WriteLine(lineSecondFile);
                        }
                        lineFirstFile = firstReader.ReadLine();
                        lineSecondFile = secondReader.ReadLine();
                    }
                    while ((lineFirstFile = firstReader.ReadLine()) != null)
                    {
                        writer.WriteLine(lineFirstFile);
                    }

                    while ((lineSecondFile = secondReader.ReadLine()) != null)
                    {
                        writer.WriteLine(lineSecondFile);
                    }
                }
            }

        }
    }
}
