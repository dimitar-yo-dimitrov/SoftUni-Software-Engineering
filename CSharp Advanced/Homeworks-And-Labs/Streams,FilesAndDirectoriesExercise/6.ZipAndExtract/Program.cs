using System;
using System.IO.Compression;

namespace _6.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory =
                @"C:\Users\mariq\source\repos\Streams,FilesAndDirectoriesExercise\6.ZipAndExtract\bin\Debug\net5.0\resultDir";
            string targetDirectory = 
                @"C:\Users\mariq\source\repos\Streams,FilesAndDirectoriesExercise\6.ZipAndExtract\bin\Debug\net5.0\result.zip";
            string destinationDirectory = 
                @"C:\Users\mariq\source\repos\Streams,FilesAndDirectoriesExercise\6.ZipAndExtract\bin\Debug\net5.0\result";

            ZipFile.CreateFromDirectory(sourceDirectory, targetDirectory);
            ZipFile.ExtractToDirectory(targetDirectory, destinationDirectory);
        }
    }
}
