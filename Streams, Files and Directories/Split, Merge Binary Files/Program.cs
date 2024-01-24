using System.Runtime;
using System.Security.Cryptography;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream sourceFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                long fileSize = sourceFile.Length;
                int parts = (int)Math.Ceiling(fileSize/2.0);
                using (FileStream firstPart = new FileStream(partOneFilePath,FileMode.Create))
                using (FileStream secongPart = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    int readedBytes;
                    int totalWrittenBytes = 0;

                    while((readedBytes = sourceFile.Read(buffer,0,buffer.Length))>0)
                    {
                        if (totalWrittenBytes + readedBytes <= parts)
                        {
                            firstPart.Write(buffer, 0, readedBytes);
                        }
                        else
                        {
                            int remainingBytes = parts - totalWrittenBytes;
                            firstPart.Write(buffer, 0, remainingBytes);
                            secongPart.Write(buffer, remainingBytes, readedBytes - remainingBytes);
                        }
                        totalWrittenBytes += readedBytes;
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream firstPart = new FileStream(partOneFilePath, FileMode.Open))
            using (FileStream secongPart = new FileStream(partTwoFilePath, FileMode.Open))
            using (FileStream joinedFile = new FileStream(joinedFilePath, FileMode.Create))
            {
                byte[] buffer = new byte[1024];
                int readedBytes;
                while ((readedBytes = firstPart.Read(buffer, 0, buffer.Length)) > 0)
                {
                    joinedFile.Write(buffer, 0, readedBytes);
                }

                while ((readedBytes = secongPart.Read(buffer, 0, buffer.Length)) > 0)
                {
                    joinedFile.Write(buffer, 0, readedBytes);
                }
            }
        }
    }
}

