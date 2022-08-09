using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine()
                .Split("\\");

            string fileAndExtasion = path[path.Length - 1];

            string[] partsPath = fileAndExtasion.Split(".");

            string fileName = partsPath[0];
            string fileExtasion = partsPath[1];
            
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtasion}");
        }
    }
}
