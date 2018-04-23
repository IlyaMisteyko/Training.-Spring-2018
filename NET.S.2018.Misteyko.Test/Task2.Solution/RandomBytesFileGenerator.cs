using System;
using System.IO;
using Task2.Solution;

namespace Task_2
{
    public class RandomBytesFileGenerator: RandomFileGenerator
    {
        //public string WorkingDirectory => "Files with random bytes";

        //public string FileExtension => ".bytes";

        public RandomBytesFileGenerator() : base("Files with random bytes", ".bytes") { }


        protected override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }
    }
}