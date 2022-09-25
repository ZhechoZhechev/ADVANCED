using System.IO;

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
            using FileStream binaryStream = new FileStream(sourceFilePath, FileMode.Open);
            using FileStream output1 = new FileStream(partOneFilePath, FileMode.Create);
            using FileStream output2 = new FileStream(partTwoFilePath, FileMode.Create);

            int odd = binaryStream.Length %2 == 1? 1 :0;
            byte[] buffer1 = new byte[binaryStream.Length /2 + odd];
            binaryStream.Read(buffer1);
            output1.Write(buffer1);

            byte[] buffer2 = new byte[binaryStream.Length / 2];
            binaryStream.Read(buffer2);
            output1.Write(buffer2);


        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using FileStream output = new FileStream(joinedFilePath, FileMode.Create);
            using FileStream StreamOne= new FileStream(partOneFilePath, FileMode.Open);
            using FileStream StreamTwo = new FileStream(partTwoFilePath, FileMode.Open);

            byte[] bytesBuffer1 = new byte[StreamOne.Length];
            StreamOne.Read(bytesBuffer1);
            output.Write(bytesBuffer1);
            byte[] bytesBuffer2 = new byte[StreamTwo.Length];
            StreamTwo.Read(bytesBuffer2);
            output.Write(bytesBuffer2);

            
        }
    }
}
