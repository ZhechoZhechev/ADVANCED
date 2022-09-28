namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream read = new FileStream(inputFilePath, FileMode.Open);
            using FileStream write = new FileStream(outputFilePath, FileMode.Create);

            byte[] buffer = new byte[512];

            //read.Read(buffer);
            //write.Write(buffer);

            while (true)
            {

                int size = read.Read(buffer, 0, buffer.Length);

                if (size == 0)
                {
                    break;
                }

                write.Write(buffer, 0, size);
            }

        }
    }
}
