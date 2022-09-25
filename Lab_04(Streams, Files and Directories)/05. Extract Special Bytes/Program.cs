using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtractBytes
{
    public class ExtractBytes
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
            using FileStream binaryStream = new FileStream(binaryFilePath, FileMode.Open);
            using FileStream bytesStream = new FileStream(bytesFilePath, FileMode.Open);
            using FileStream output = new FileStream(outputPath, FileMode.Create);

            byte[] bytesBuffer = new byte[bytesStream.Length];
            bytesStream.Read(bytesBuffer);
            byte[] imageBuffer = new byte[bytesStream.Length];
            bytesStream.Read(imageBuffer);

            for (int i = 0; i < imageBuffer.Length; i++)
            {
                for (int j = 0; j < bytesBuffer.Length; j++)
                {
                    if (imageBuffer[i] == bytesBuffer[j])
                    {
                        output.Write(new byte[] { imageBuffer[i] });
                    }
                }
            }
        }
    }
}
