using System.Text;

namespace ExtractSpecialBytes
{
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (StreamReader imgReader = new StreamReader(binaryFilePath))
            using (StreamReader bytesReader = new StreamReader(bytesFilePath))
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                byte[] imgBytes = File.ReadAllBytes(binaryFilePath);
                List<string> bytesList = new List<string>();
                StringBuilder str = new StringBuilder();
                while (imgReader.EndOfStream)
                {
                    bytesList.Add(imgReader.ReadLine());
                }
                foreach (var item in imgBytes)
                {
                    if (bytesList.Contains(item.ToString()))
                    {
                        str.AppendLine(item.ToString());
                    }
                }
                writer.WriteLine(str.ToString().Trim());
            }
        }
    }
}
