namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            using (StringReader reader = new StringReader(folderPath))
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                long size = 0;
                DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
                FileInfo[] files = dirInfo.GetFiles("*", SearchOption.AllDirectories);
                foreach (FileInfo file in files)
                {
                    size+= file.Length;
                }
                writer.WriteLine(size/1024/1024);
            }
        }
    }
}
